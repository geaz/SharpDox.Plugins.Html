using SharpDox.Plugins.Html.Templates;
using SharpDox.UML;
using System;
using System.Collections.Generic;
using System.IO;

namespace SharpDox.Plugins.Html.Steps
{
    internal class AssetsStep : StepBase
    {
        public AssetsStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            var dynamicCss = new Css { HtmlConfig = StepInput.HtmlConfig };
            EnsureFolder(Path.Combine(StepInput.OutputPath, "assets", "css"));
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "assets", "css", "dynamic.css"), dynamicCss.TransformText());

            CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets"), Path.Combine(StepInput.OutputPath, "assets"));
            CopyImages(StepInput.SDProject.Images, Path.Combine(StepInput.OutputPath, "assets"));
            CopyImage(StepInput.SDProject.LogoPath, StepInput.OutputPath);
        }

        private void CopyFolder(string input, string output)
        {
            EnsureFolder(output);

            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, Path.GetFileName(file)));
                File.Copy(file, Path.Combine(output, Path.GetFileName(file)), true);
            }

            foreach (var dir in Directory.EnumerateDirectories(input))
            {
                CopyFolder(dir, Path.Combine(output, Path.GetFileName(dir)));
            }
        }
             
        /*private void CopyDiagrams(string diagramPath)
        {
            Directory.CreateDirectory(diagramPath);

            foreach (var sdRepository in StepInput.SDProject.Repositories.Values)
            {
                foreach (var sdType in sdRepository.GetAllTypes())
                {
                    if (!sdType.IsClassDiagramEmpty())
                    {
                        ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, sdType.Guid + ".png"));
                        sdType.GetClassDiagram().ToPng(Path.Combine(diagramPath, sdType.Guid + ".png"));
                    }
                }

                foreach (var sdMethod in sdRepository.GetAllMethods())
                {
                    if (!sdMethod.IsSequenceDiagramEmpty())
                    {
                        ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, sdMethod.Guid + ".png"));
                        sdMethod.GetSequenceDiagram(StepInput.SDProject).ToPng(Path.Combine(diagramPath, sdMethod.Guid + ".png"));
                    }
                }
            }
        }*/

        private void CopyImages(IEnumerable<string> images, string outputPath)
        {
            foreach (var image in images)
            {
                CopyImage(image, Path.Combine(outputPath, "images"));
            }
        }

        private void CopyImage(string imagePath, string outputPath)
        {
            if (!String.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, Path.GetFileName(imagePath)));
                File.Copy(imagePath, Path.Combine(outputPath, Path.GetFileName(imagePath)), true);
            }
        }

        private void EnsureFolder(string pathToFolder)
        {
            if (!Directory.Exists(pathToFolder))
            {
                Directory.CreateDirectory(pathToFolder);
            }
        }
    }
}
