using System.IO;
using SharpDox.Plugins.Html.Templates;

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
    }
}
