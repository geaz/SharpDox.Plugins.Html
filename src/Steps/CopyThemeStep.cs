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

            CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "app"), StepInput.OutputPath);
            CopyFolder(StepInput.HtmlConfig.Theme, StepInput.OutputPath);
            CopyImages(StepInput.SDProject.Images, Path.Combine(StepInput.OutputPath, "data"));
            CopyImage(StepInput.SDProject.LogoPath, StepInput.OutputPath);
        }
        
        private void CreateDynamicCSS()
        {
            var dynamicCss = new Css { HtmlConfig = StepInput.HtmlConfig };
            File.WriteAllText(Path.Combine(StepInput.OutputPath, "data", "dynamic.css"), dynamicCss.TransformText());
        }

        private void CopyFavIcon()
        {
            if(!string.IsNullOrEmpty(StepInput.HtmlConfig.FavIcon))
            {
                var outputFilePath = Path.Combine(StepInput.OutputPath, "data", "favicon.ico");
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
