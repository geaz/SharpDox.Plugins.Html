using System.IO;

namespace SharpDox.Plugins.Html.Steps
{
    internal class PreBuildStep : StepBase
    {
        public PreBuildStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            ExecuteOnStepMessage(StepInput.HtmlStrings.CreatingFolders);

            CreateFolder(StepInput.OutputPath, "namespace");
            CreateFolder(StepInput.OutputPath, "type");
            CreateFolder(StepInput.OutputPath, "article");
            CreateFolder(StepInput.OutputPath, "assets");
        }

        public static void CreateFolder(string path, string name)
        {
            if (!Directory.Exists(Path.Combine(path, name)))
            {
                Directory.CreateDirectory(Path.Combine(path, name));
            }
        }
    }
}
