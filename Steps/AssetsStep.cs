using SharpDox.Model.Repository;
using SharpDox.Plugins.Html.Templates;
using SharpDox.UML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yahoo.Yui.Compressor;

namespace SharpDox.Plugins.Html.Steps
{
    public class AssetsStep : Step
    {
        public override void ProcessStep(HtmlExporter htmlExporter)
        {
            htmlExporter.ExecuteOnStepProgress(40);

            #if DEBUG
                var dynamicCss = new Css { HtmlConfig = htmlExporter.HtmlConfig };
                EnsureFolder(Path.Combine(htmlExporter.OutputPath, "assets", "css"));
                File.WriteAllText(Path.Combine(htmlExporter.OutputPath, "assets", "css", "dynamic.css"), dynamicCss.TransformText());

                CopyFolder(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "css"), Path.Combine(htmlExporter.OutputPath, "assets", "css"));
                CopyFolder(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "js"), Path.Combine(htmlExporter.OutputPath, "assets", "js"));
            #else
                CopyCompressedCss(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "css"), Path.Combine(htmlExporter.OutputPath, "assets", "css"));
                CopyCompressedJs(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "js", "vendor"), Path.Combine(htmlExporter.OutputPath, "assets", "js"), "vendor.js");
                CopyCompressedJs(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "js", "app"), Path.Combine(htmlExporter.OutputPath, "assets", "js"), "app.js");
                CopyCompressedJs(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "js", "frame"), Path.Combine(htmlExporter.OutputPath, "assets", "js"), "frame.js");
            #endif

            CopyFolder(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "font"), Path.Combine(htmlExporter.OutputPath, "assets", "font"));
            CopyFolder(htmlExporter, Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "assets", "images"), Path.Combine(htmlExporter.OutputPath, "assets", "images"));
            
            CopyImages(htmlExporter, htmlExporter.Repository.Images, Path.Combine(htmlExporter.OutputPath, "assets"));
            CopyImage(htmlExporter, htmlExporter.Repository.ProjectInfo.LogoPath, htmlExporter.OutputPath);

            htmlExporter.CurrentStep = new CreateHtmlStep();
        }

        private void CopyFolder(HtmlExporter htmlExporter, string input, string output)
        {
            EnsureFolder(output);

            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, Path.GetFileName(file)));
                File.Copy(file, Path.Combine(output, Path.GetFileName(file)), true);
            }

            foreach (var dir in Directory.EnumerateDirectories(input))
            {
                CopyFolder(htmlExporter, dir, Path.Combine(output, Path.GetFileName(dir)));
            }
        }

        private void CopyCompressedCss(HtmlExporter htmlExporter, string input, string output)
        {
            htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, "style.css"));
            EnsureFolder(output);

            var completeCss = string.Empty;
            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                completeCss += File.ReadAllText(file);
            }

            var dynamicCss = new Css { HtmlConfig = htmlExporter.HtmlConfig };
            completeCss += dynamicCss.TransformText();

            var compressor = new CssCompressor();
            compressor.RemoveComments = true;

            File.WriteAllText(Path.Combine(output, "style.css"), compressor.Compress(completeCss));
        }

        private void CopyCompressedJs(HtmlExporter htmlExporter, string input, string output, string compressedFileName)
        {
            htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, compressedFileName));
            EnsureFolder(output);

            var completeJs = string.Empty;
            var files = Directory.EnumerateFiles(input);
            foreach (var file in files)
            {
                completeJs += File.ReadAllText(file) + " ";                
            }

            File.WriteAllText(Path.Combine(output, compressedFileName), new JavaScriptCompressor().Compress(completeJs));
        }

        /*private void CopyDiagrams(HtmlExporter htmlExporter, string outputPath)
        {
            var diagramPath = Path.Combine(outputPath, "images", "diagrams");
            Directory.CreateDirectory(diagramPath);

            foreach (var sdType in htmlExporter.Repository.GetAllTypes())
            {
                if(!sdType.IsClassDiagramEmpty())
                {
                    htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, sdType.Guid + ".png"));
                    sdType.GetClassDiagram().ToPng(Path.Combine(diagramPath, sdType.Guid + ".png"));
                }
            }

            foreach (var sdMethod in htmlExporter.Repository.GetAllMethods())
            {
                if (!sdMethod.IsSequenceDiagramEmpty())
                {
                    htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, sdMethod.Guid + ".png"));
                    sdMethod.GetSequenceDiagram(htmlExporter.Repository.GetAllTypes()).ToPng(Path.Combine(diagramPath, sdMethod.Guid + ".png"));
                }
            }
        }*/

        private void CopyImages(HtmlExporter htmlExporter, IEnumerable<string> images, string outputPath)
        {
            foreach (var image in images)
            {
                CopyImage(htmlExporter, image, Path.Combine(outputPath, "images"));
            }
        }

        private void CopyImage(HtmlExporter htmlExporter, string imagePath, string outputPath)
        {
            if (!String.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                htmlExporter.ExecuteOnStepMessage(string.Format(htmlExporter.HtmlStrings.CopyingFile, Path.GetFileName(imagePath)));
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
