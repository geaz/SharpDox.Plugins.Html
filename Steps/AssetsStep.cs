using SharpDox.Plugins.Html.Templates;
using SharpDox.UML;
using System;
using System.Collections.Generic;
using System.IO;
using Yahoo.Yui.Compressor;

namespace SharpDox.Plugins.Html.Steps
{
    internal class AssetsStep : StepBase
    {
        public AssetsStep(int progressStart, int progressEnd) : base(new StepRange(progressStart, progressEnd)) { }

        public override void RunStep()
        {
            #if DEBUG
                var dynamicCss = new Css { HtmlConfig = StepInput.HtmlConfig };
                EnsureFolder(Path.Combine(StepInput.OutputPath, "assets", "css"));
                File.WriteAllText(Path.Combine(StepInput.OutputPath, "assets", "css", "dynamic.css"), dynamicCss.TransformText());

                CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "css"), Path.Combine(StepInput.OutputPath, "assets", "css"));
                CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "js"), Path.Combine(StepInput.OutputPath, "assets", "js"));
            #else
                CopyCompressedCss(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "css"), Path.Combine(StepInput.OutputPath, "assets", "css"));
                CopyCompressedJs(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "js", "vendor"), Path.Combine(StepInput.OutputPath, "assets", "js"), "vendor.js");
                CopyCompressedJs(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "js", "app"), Path.Combine(StepInput.OutputPath, "assets", "js"), "app.js");
                CopyCompressedJs(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "js", "frame"), Path.Combine(StepInput.OutputPath, "assets", "js"), "frame.js");
            #endif

            CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "font"), Path.Combine(StepInput.OutputPath, "assets", "font"));
            CopyFolder(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "assets", "images"), Path.Combine(StepInput.OutputPath, "assets", "images"));

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

        private void CopyCompressedCss(string input, string output)
        {
            ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, "style.css"));
            EnsureFolder(output);

            var completeCss = string.Empty;
            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                completeCss += File.ReadAllText(file);
            }

            var dynamicCss = new Css { HtmlConfig = StepInput.HtmlConfig };
            completeCss += dynamicCss.TransformText();

            var compressor = new CssCompressor {RemoveComments = true};

            File.WriteAllText(Path.Combine(output, "style.css"), compressor.Compress(completeCss));
        }

        private void CopyCompressedJs(string input, string output, string compressedFileName)
        {
            ExecuteOnStepMessage(string.Format(StepInput.HtmlStrings.CopyingFile, compressedFileName));
            EnsureFolder(output);

            var completeJs = string.Empty;
            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                completeJs += File.ReadAllText(file) + "; ";                
            }

            File.WriteAllText(Path.Combine(output, compressedFileName), new JavaScriptCompressor().Compress(completeJs));
        }

        private void CopyDiagrams(string diagramPath)
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
