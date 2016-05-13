using System.IO;
using SharpDox.Sdk.Config.Lists;
using System.Collections.Generic;

namespace SharpDox.Plugins.Html
{
    public class ThemeList : ComboBoxList
    {
        private Dictionary<string, string> _themes;

        public ThemeList()
        {
            _themes = new Dictionary<string, string>();

            var themeFolder = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "themes");
            var themes = Directory.GetDirectories(themeFolder);
            foreach (var theme in themes)
            {
                var themeName = Path.GetFileName(theme);
                Add(themeName, themeName);
                _themes.Add(themeName, theme);
            }
        }

        public string GetThemeFolder(string theme)
        {
            return _themes[theme];
        }
    }
}
