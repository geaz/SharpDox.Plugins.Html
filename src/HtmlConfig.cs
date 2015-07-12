using SharpDox.Sdk.Config;
using SharpDox.Sdk.Config.Attributes;
using System;
using System.ComponentModel;

namespace SharpDox.Plugins.Html
{
    [Name(typeof(HtmlStrings), "Html")]
    public class HtmlConfig : IConfigSection
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _favIcon;
        private string _theme;
        private string _primaryColor;
        private string _secondaryColor;
        private bool _disableSequenceDiagrams;
        private string _footerLine;

        [Name(typeof(HtmlStrings), "FavIcon")]
        [ConfigEditor(EditorType.Filepicker, "Icon File(.png; .ico)|*.png; *.ico")]
        public string FavIcon
        {
            get { return _favIcon; }
            set
            {
                _favIcon = value;
                OnPropertyChanged("FavIcon");
            }
        }

        [Required]
        [ConfigEditor(EditorType.ComboBox, typeof(ThemeList))]
        [Name(typeof(HtmlStrings), "Theme")]
        public string Theme
        {
            get { return _theme; }
            set
            {
                if (_theme != value)
                {
                    _theme = value;
                    OnPropertyChanged("Theme");
                }
            }
        }

        [Name(typeof(HtmlStrings), "PrimaryColor")]
        [ConfigEditor(EditorType.Colorpicker)]
        public string PrimaryColor
        {
            get { return _primaryColor ?? "#F5F4F0"; }
            set
            {
                _primaryColor = value;
                OnPropertyChanged("PrimaryColor");
            }
        }

        [Name(typeof(HtmlStrings), "SecondaryColor")]
        [ConfigEditor(EditorType.Colorpicker)]
        public string SecondaryColor
        {
            get { return _secondaryColor ?? "#F58026"; }
            set
            {
                _secondaryColor = value;
                OnPropertyChanged("SecondaryColor");
            }
        }

        [Name(typeof(HtmlStrings), "DisableSequenceDiagrams")]
        public bool DisableSequenceDiagrams
        {
            get { return _disableSequenceDiagrams; }
            set
            {
                _disableSequenceDiagrams = value;
                OnPropertyChanged("DisableSequenceDiagrams");
            }
        }

        [Name(typeof(HtmlStrings), "FooterLine")]
        [ConfigEditor(EditorType.Markdown)]
        public string FooterLine
        {
            get { return _footerLine; }
            set
            {
                _footerLine = value;
                OnPropertyChanged("FooterLine");
            }
        }

        public Guid Guid { get { return new Guid("9E8E8BC4-BFDD-11E3-A297-170828518C08"); } }        
    }
}
