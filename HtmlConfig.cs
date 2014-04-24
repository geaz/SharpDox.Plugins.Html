using SharpDox.Sdk.Config;
using SharpDox.Sdk.Config.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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

        private string _headerBackground;
        private string _subheaderBackground;
        private string _color;
        private bool _disableSequenceDiagrams;
        private string _footerLine;

        [Name(typeof(HtmlStrings), "HeaderBackground")]
        [ConfigEditor(EditorType.Colorpicker)]
        public string HeaderBackground
        {
            get { return _headerBackground ?? "#3F72DB"; }
            set
            {
                _headerBackground = value;
                OnPropertyChanged("HeaderBackground");
            }
        }

        [Name(typeof(HtmlStrings), "SubHeaderBackground")]
        [ConfigEditor(EditorType.Colorpicker)]
        public string SubHeaderBackground
        {
            get { return _subheaderBackground ?? "#2862db"; }
            set
            {
                _subheaderBackground = value;
                OnPropertyChanged("SubheaderBackground");
            }
        }

        [Name(typeof(HtmlStrings), "Color")]
        [ConfigEditor(EditorType.Colorpicker)]
        public string Color
        {
            get { return _color ?? "#FFFFFF"; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
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
