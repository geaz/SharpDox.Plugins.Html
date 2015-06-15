using SharpDox.Plugins.Html.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SharpDox.Plugins.Html.Steps
{
    internal class CopyThemeStep : StepBase
    {
        public CopyThemeStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            CreateDynamicCSS();
            CopyFavIcon();

            CopyFolder(StepInput.HtmlConfig.Theme, StepInput.OutputPath);
            CopyImages(StepInput.SDProject.Images, Path.Combine(StepInput.OutputPath, "assets"));
            CopyImage(StepInput.SDProject.LogoPath, StepInput.OutputPath);
        }

        private void CreateDynamicCSS()
        {
            var dynamicCss = new Css { HtmlConfig = StepInput.HtmlConfig };
            EnsureFolder(Path.Combine(StepInput.OutputPath, "assets", "css"));
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "assets", "css", "dynamic.css"), dynamicCss.TransformText());
        }

        private void CopyFavIcon()
        {
            if(!string.IsNullOrEmpty(StepInput.HtmlConfig.FavIcon))
            {
                var outputFilePath = Path.Combine(StepInput.OutputPath, "favicon.ico");
                if (Path.GetExtension(StepInput.HtmlConfig.FavIcon) == "ico")
                {
                    File.Copy(StepInput.HtmlConfig.FavIcon, outputFilePath);
                }
                else
                {
                    using (FileStream stream = File.OpenWrite(outputFilePath))
                    {
                        var bitmap = (Bitmap)Image.FromFile(StepInput.HtmlConfig.FavIcon);
                        Icon.FromHandle(bitmap.GetHicon()).Save(stream);
                    }
                }
            }
        }

        private void CopyFolder(string input, string output)
        {
            EnsureFolder(output);

            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
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
                EnsureFolder(outputPath);
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
