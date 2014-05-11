using SharpDox.Plugins.Html.Templates.Nav;
using SharpDox.Plugins.Html.Templates.Sites;
using System;
using System.IO;
using System.Linq;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CreateHtmlStep : StepBase
    {
        public CreateHtmlStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            var navigation = GetNavigation();
            var indexTemplate = new IndexTemplate { Navigation = navigation };
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "index.html"), indexTemplate.TransformText());

            var homeTemplate = new HomeTemplate();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "article", "home.html"), homeTemplate.TransformText());

            var namespaceCount = 0d;
            var namespaceTotal = StepInput.SDProject.Repositories.Values.Sum(repository => repository.GetAllNamespaces().Count);
            foreach (var repository in StepInput.SDProject.Repositories.Values)
            {
                foreach (var nameSpace in repository.GetAllNamespaces())
                {
                    ExecuteOnStepProgress(Convert.ToInt16((namespaceCount/namespaceTotal)*50) + 50);
                    ExecuteOnStepMessage(StepInput.HtmlStrings.CreateFilesForNamespace + ": " + nameSpace.Fullname);
                    namespaceCount++;

                    var namespaceTemplate = new NamespaceTemplate { Namespace = nameSpace };
                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "namespace", nameSpace.Fullname + ".html"), namespaceTemplate.TransformText());

                    foreach (var type in nameSpace.Types)
                    {
                        var typeTemplate = new TypeTemplate { SDType = type, };
                        File.WriteAllText(Path.Combine(StepInput.OutputPath, "type", type.ShortIdentifier + ".html"), typeTemplate.TransformText());
                    }
                }
            }
        }

        private string GetNavigation()
        {
            var indexNavTemplate = new IndexNavTemplate();
            var indexNav = indexNavTemplate.TransformText().Trim();

            return indexNav;
        }
    }
}
