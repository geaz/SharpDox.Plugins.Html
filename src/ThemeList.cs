using System.IO;
using SharpDox.Sdk.Config.Lists;

namespace SharpDox.Plugins.Html
{
    public class ThemeList : ComboBoxList
    {
        public ThemeList()
        {
            var themeFolder = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "themes");
            var themes = Directory.GetDirectories(themeFolder);
            foreach (var theme in themes)
            {
                Add(theme, Path.GetFileName(theme));
            }
        }
    }
}
