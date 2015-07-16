using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SharpDox.Model.Documentation.Article;
using SharpDox.Plugins.Html.Templates;
using SharpDox.Plugins.Html.Templates.Navigation;
using SharpDox.Plugins.Html.Templates.Repository;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CreateDataStep : StepBase
    {
        public CreateDataStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            CreateProjectData();
            CreateStringData();
            CreateNavigationData();
            CreateNamespaceData();
            CreateArticleData();
        }

        private void CreateProjectData()
        {
            ExecuteOnStepProgress(0);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingProjectData);

            var projectData = new ProjectData();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Project.js"), projectData.TransformText());
        }

        private void CreateStringData()
        {
            ExecuteOnStepProgress(10);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingStringData);

            var stringData = new Strings();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Strings.js"), stringData.TransformText());
        }

        private void CreateNavigationData()
        {
            ExecuteOnStepProgress(20);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingNavigationData);

            var navigationData = new Navigation();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Navigation.js"), navigationData.TransformText());  
        }

        private void CreateNamespaceData()
        {
            ExecuteOnStepProgress(30);

            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxNamespace in sdSolution.Value.GetAllNamespaces())
                {
                    ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CreatingNamespaceData, targetFxNamespace.Key));
                    
                    var namespaceString = string.Format("{{{0}}}",
                        string.Join(",", targetFxNamespace.Value.Select(sdTargetNamespace =>
                        new NamespaceData { Namespace = sdTargetNamespace.Value, TargetFx = sdTargetNamespace.Key }.TransformText())));
                    namespaceString = Regex.Replace(namespaceString, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1").Replace(Environment.NewLine, "");

                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "namespaces", targetFxNamespace.Key + ".json"), namespaceString); 
                }
            }
        }

        private void CreateArticleData()
        {
            ExecuteOnStepProgress(90);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingArticleData);

            var articles = new List<SDArticle>();
            foreach (var article in StepInput.SDProject.Articles.GetElementOrDefault(StepInput.CurrentLanguage))
            {
                AddArticle(articles, article);
            }

            var articleData = new ArticleData { SDArticles = articles };
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Articles.js"), articleData.TransformText());
        }

        private void AddArticle(List<SDArticle> sdArticles, SDArticle sdArticle)
        {
            sdArticles.Add(sdArticle);
            foreach (var article in sdArticle.Children)
            {
                AddArticle(sdArticles, article);
            }
        }
    }
}
