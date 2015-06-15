using System.Collections.Generic;
using System.IO;
using SharpDox.Model.Documentation.Article;
using SharpDox.Plugins.Html.Templates;
using SharpDox.Plugins.Html.Templates.Repository;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CreateDataStep : StepBase
    {
        public CreateDataStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            CreateDataFolder();
            CreateProjectData();
            CreateStringData();
            CreateArticleData();
        }

        private void CreateDataFolder()
        {
            if (!Directory.Exists(Path.Combine(StepInput.OutputPath, "data")))
            {
                Directory.CreateDirectory(Path.Combine(StepInput.OutputPath, "data"));
            }
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

        private void CreateArticleData()
        {
            ExecuteOnStepProgress(20);
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
