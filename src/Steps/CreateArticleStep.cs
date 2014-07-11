using System.IO;
using SharpDox.Model.Documentation.Article;
using SharpDox.Plugins.Html.Templates.Sites;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CreateArticleStep : StepBase
    {
        public CreateArticleStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            if (StepInput.SDProject.Articles.Count > 0)
            {
                var articles = StepInput.SDProject.Articles.ContainsKey(StepInput.CurrentLanguage)
                    ? StepInput.SDProject.Articles[StepInput.CurrentLanguage]
                    : StepInput.SDProject.Articles["default"];

                foreach (var article in articles)
                {
                    ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CreatingArticle, article.Title));
                    CreateArticle(article);
                }
            }
        }

        private void CreateArticle(SDArticle article)
        {
            if (article.Content != null)
            {
                var articleTemplate = new ArticleTemplate { Article = article };
                File.WriteAllText(Path.Combine(StepInput.OutputPath, "article", string.Format("{0}.html", article.Id)), articleTemplate.TransformText());
            }

            if (!(article is SDDocPlaceholder))
            {
                foreach (var child in article.Children)
                {
                    CreateArticle(child);
                }
            }
        }
    }
}
