using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CommonMark;
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
            CreateTypeData();
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
                    
                    var namespaceString =   string.Join(",", targetFxNamespace.Value.Select(sdTargetNamespace =>
                                            new NamespaceData { Namespace = sdTargetNamespace.Value, TargetFx = sdTargetNamespace.Key.TargetFx }.TransformText()));

                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "namespaces", targetFxNamespace.Key + ".json"), namespaceString.MinifyJson()); 
                }
            }
        }

        private void CreateTypeData()
        {
            ExecuteOnStepProgress(60);
            foreach (var sdSolution in StepInput.SDProject.Solutions)
            {
                foreach (var targetFxType in sdSolution.Value.GetAllTypes())
                {
                    ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CreatingTypeData, targetFxType.Key));

                    var typeString =    string.Join(",", targetFxType.Value.Select(sdTargetType =>
                                        new TypeData { Type = sdTargetType.Value, TargetFx = sdTargetType.Key.TargetFx, Repository = sdTargetType.Key}.TransformText()));

                    File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "types", targetFxType.Key.RemoveIllegalPathChars() + ".json"), typeString.MinifyJson());
                }
            }
        }

        private void CreateArticleData()
        {
            ExecuteOnStepProgress(90);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingArticleData);

            var projectDescription = StepInput.SDProject.Descriptions.GetElementOrDefault(StepInput.CurrentLanguage);
            var homeData = new ArticleData()
            {
                Title = "Home",
                SubTitle = StepInput.HtmlStrings.Description,
                Content = CommonMarkConverter.Convert(projectDescription.Transform(new Helper(StepInput.SDProject).TransformLinkToken)).ToObjectString()
            };
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "articles", "home.json"), homeData.TransformText().MinifyJson());

            foreach (var article in StepInput.SDProject.Articles.GetElementOrDefault(StepInput.CurrentLanguage))
            {
                AddArticle(article);
            }
        }

        private void AddArticle(SDArticle sdArticle)
        {
            if (!(sdArticle is SDArticlePlaceholder) && !(sdArticle is SDDocPlaceholder))
            {
                var articleData = new ArticleData
                {
                    Title = sdArticle.Title,
                    Content = CommonMarkConverter.Convert(sdArticle.Content.Transform(new Helper(StepInput.SDProject).TransformLinkToken)).ToObjectString()
                };
                File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "articles", sdArticle.Id + ".json"), articleData.TransformText().MinifyJson());
            }

            foreach (var article in sdArticle.Children)
            {
                AddArticle(article);
            }
        }
    }
}
