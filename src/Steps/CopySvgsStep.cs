using System.IO;
using SharpDox.UML;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CopySvgsStep : StepBase
    {
        public CopySvgsStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            CreateSvgFolder();
            CopyClassDiagrams();
        }

        private void CreateSvgFolder()
        {
            if (!Directory.Exists(Path.Combine(StepInput.OutputPath, "data", "svg")))
            {
                Directory.CreateDirectory(Path.Combine(StepInput.OutputPath, "data", "svg"));
            }
        }

        private void CopyClassDiagrams()
        {
            foreach (var sdSolution in StepInput.SDProject.Solutions.Values)
            {
                foreach (var sdType in sdSolution.GetAllTypes().Values)
                {
                    foreach (var sdTargetType in sdType)
                    {
                        if (!sdTargetType.Value.IsClassDiagramEmpty())
                        {
                            var fileName = string.Format("{0}-{1}.svg", sdTargetType.Key.Name, sdTargetType.Value.ShortIdentifier);
                            ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, fileName));

                            var classDiagram = sdTargetType.Value.GetClassDiagram().ToSvg();
                            var classDiagramString = classDiagram.Transform(new Helper(StepInput.SDProject).TransformLinkToken);
                            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "svg", fileName), classDiagramString);
                        }
                    }
                }
            }
        }
    }
}
