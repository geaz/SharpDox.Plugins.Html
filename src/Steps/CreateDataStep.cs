using System.Collections.Generic;
using System.IO;
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
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingNamespaceData);

            var namespaceData = new NamespaceData();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Namespaces.js"), namespaceData.TransformText()); 
        }

        private void CreateTypeData()
        {
            ExecuteOnStepProgress(40);
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingTypeData);

            var typeData = new TypeData();
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "Types.js"), typeData.TransformText());  
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
