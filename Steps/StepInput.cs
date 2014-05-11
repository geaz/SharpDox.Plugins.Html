using SharpDox.Model;
using SharpDox.Plugins.Html.Templates.Strings;

namespace SharpDox.Plugins.Html.Steps
{
    internal static class StepInput
    {
        public static void InitStepinput(SDProject sdProject, string outputPath, string currentLanguage, IStrings docStrings, HtmlStrings htmlStrings, HtmlConfig htmlConfig)
        {
            SDProject = sdProject;
            OutputPath = outputPath;
            CurrentLanguage = currentLanguage;
            DocStrings = docStrings;
            HtmlStrings = htmlStrings;
            HtmlConfig = htmlConfig;
        }

        public static SDProject SDProject { get; set; }
        public static string OutputPath { get; set; }
        public static string CurrentLanguage { get; set; }
        public static IStrings DocStrings { get; set; }
        public static HtmlStrings HtmlStrings { get; set; }
        public static HtmlConfig HtmlConfig { get; set; }
    }
}
