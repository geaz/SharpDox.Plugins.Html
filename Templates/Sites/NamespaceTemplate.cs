﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 11.0.0.0
//  
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SharpDox.Plugins.Html.Templates.Sites
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using SharpDox.Model.Repository;
    using SharpDox.Sdk.Config;
    using MarkdownSharp;
    using SharpDox.Sdk;
    using SharpDox.Plugins.Html.Templates.Strings;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class NamespaceTemplate : NamespaceTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@" 

<html>
<!--[if lt IE 7]>      <html class=""no-js lt-ie9 lt-ie8 lt-ie7""> <![endif]-->
<!--[if IE 7]>         <html class=""no-js lt-ie9 lt-ie8""> <![endif]-->
<!--[if IE 8]>         <html class=""no-js lt-ie9""> <![endif]-->
<!--[if gt IE 8]><!--> <html class=""no-js""> <!--<![endif]-->
    <head>
        <meta charset=""utf-8"">
        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
        <title>");
            
            #line 20 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Repository.ProjectInfo.ProjectName));
            
            #line default
            #line hidden
            this.Write(" - ");
            
            #line 20 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace.Fullname));
            
            #line default
            #line hidden
            this.Write("</title>\r\n        <meta name=\"viewport\" content=\"width=device-width\">\r\n\r\n\t\t");
            
            #line 23 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 #if DEBUG 
            
            #line default
            #line hidden
            this.Write(@"			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/0-reset.css"" />
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/1-font.css"" />
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/1-font-awesome.css"" />
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/2-typography.css"" />		
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/3-markdown.css"" />	
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/3-dropdown.css"" />			
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/3-tree.css"" />
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/layout.css"" />
			<link rel=""stylesheet"" type=""text/css"" href=""../assets/css/vs.css"" />

			<script src=""../assets/js/vendor/0-jquery.js""></script>
			<script src=""../assets/js/vendor/1-jquery-ui.custom.min.js""></script>	
			<script src=""../assets/js/vendor/1-jquery.dropdown.min.js""></script>			
			<script src=""../assets/js/vendor/1-jquery.layout.min.js""></script>
			<script src=""../assets/js/vendor/2-jquery.print.js""></script>
			<script src=""../assets/js/vendor/highlight.pack.js""></script>

			<script src=""../assets/js/frame/iframe.js""></script>
		");
            
            #line 42 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 #else 
            
            #line default
            #line hidden
            this.Write("\t\t\t<link rel=\"stylesheet\" type=\"text/css\" href=\"../assets/css/style.css\" />\r\n\t\t\t<" +
                    "script src=\"../assets/js/vendor.js\"></script>\r\n\t\t\t<script src=\"../assets/js/fram" +
                    "e.js\"></script>\r\n\t\t");
            
            #line 46 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 #endif 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t<script>hljs.initHighlightingOnLoad();</script>\r\n\r\n    </head>\r\n    <body>   " +
                    "     \r\n       \r\n\t    <div id=\"dropdown-1\" class=\"dropdown dropdown-tip\">\r\n\t\t\t<ul" +
                    " class=\"dropdown-menu\">\r\n\t\t\t\t");
            
            #line 55 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 foreach(var type in Namespace.Types) { 

					var sdType = (SDType)Repository.GetTypeByIdentifier(type.Identifier); 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<li><a href=\"../type/");
            
            #line 58 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.ShortIdentifier));
            
            #line default
            #line hidden
            this.Write(".html\"><img alt=\"Class-Icon\" src=\"../assets/images/icons/class_");
            
            #line 58 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\"> ");
            
            #line 58 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Name));
            
            #line default
            #line hidden
            this.Write("</a></li>\r\n\r\n\t\t\t\t");
            
            #line 60 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t</ul>\r\n\t\t</div>\r\n\t   \r\n\t    <div class=\"ui-layout-north\">\r\n\t\t\t<div class=\"tool" +
                    "bar\">\r\n\t\t\t\t<a href=\"#\" data-dropdown=\"#dropdown-1\" class=\"button\"><img src=\"../a" +
                    "ssets/images/icons/class_public.png\"/> ");
            
            #line 66 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Types));
            
            #line default
            #line hidden
            this.Write(" <span class=\"info\">(");
            
            #line 66 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace.Types.Count));
            
            #line default
            #line hidden
            this.Write(")</span> <i class=\"icon-caret-down\"></i></a>\r\n\t\t\t\t<div class=\"right\">\r\n\t\t\t\t\t<span" +
                    " class=\"toolbar-info\"> Assembly: ");
            
            #line 68 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace.Assemblyname));
            
            #line default
            #line hidden
            this.Write("</span>\r\n\t\t\t\t\t<a href=\"#\" id=\"print-button\" class=\"button\" title=\"");
            
            #line 69 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Print));
            
            #line default
            #line hidden
            this.Write("\"><i class=\"icon-print\"></i></a>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n        \r\n\t\t<d" +
                    "iv class=\"ui-layout-center\">\r\n\t\t\t");
            
            #line 75 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 if(Namespace.Description.Count != 0 && Namespace.Description.ContainsKey(CurrentLanguage)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<h3 class=\"box-title first-heading\">");
            
            #line 76 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Description));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\t\t\t\t\r\n\t\t\t\t<div class=\"text-box markdown\">\r\n\t\t\t\t\t");
            
            #line 79 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
	var template = new Templater(Repository, Namespace.Description[CurrentLanguage]); 
						var helper = new Helper(Repository);
						var namespaceDescription = template.TransformText(helper.TransformLinkToken); 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 83 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new Markdown().Transform(namespaceDescription)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</div>\r\n\t\t\t\t<h3 class=\"box-title\">");
            
            #line 85 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Types));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\r\n\t\t\t");
            
            #line 87 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t<h3 class=\"box-title first-heading\">");
            
            #line 89 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Types));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\r\n\t\t\t");
            
            #line 91 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t<div class=\"table-box\">\r\n\t\t\t\t<table>\r\n\t\t\t\t\t<thead>\r\n\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t<td><" +
                    "/td>\r\n\t\t\t\t\t\t\t<td>Name</td>\r\n\t\t\t\t\t\t\t<td>Description</td>\r\n\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t</the" +
                    "ad>\r\n\t\t\t\t\t<tbody>\t\t\t\r\n\r\n\t\t\t\t\t\t");
            
            #line 104 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 var even = false; 
						foreach(var type in Namespace.Types) { 
							var sdType = (SDType)Repository.GetTypeByIdentifier(type.Identifier); 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t\t<tr ");
            
            #line 108 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 if(even) { even = false; 
            
            #line default
            #line hidden
            this.Write(" class=\"even\" ");
            
            #line 108 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } else { even = true; } 
            
            #line default
            #line hidden
            this.Write(">\r\n\t\t\t\t\t\t\t\t<td class=\"iconColumn\">\r\n\t\t\t\t\t\t\t\t\t<img alt=\"Class-Icon\" src=\"../assets" +
                    "/images/icons/class_");
            
            #line 110 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\">\r\n\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t\t<a title=\"");
            
            #line 113 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Name));
            
            #line default
            #line hidden
            this.Write("\" href=\"../type/");
            
            #line 113 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.ShortIdentifier));
            
            #line default
            #line hidden
            this.Write(".html\">");
            
            #line 113 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Name));
            
            #line default
            #line hidden
            this.Write("</a>\r\n\t\t\t\t\t\t\t\t</td>\t\r\n\t\t\t\t\t\t\t\t<td class=\"markdown\">\r\n\t\t\t\t\t\t\t\t\t");
            
            #line 116 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 if(sdType.Documentation.ContainsKey(CurrentLanguage)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t\t\t");
            
            #line 117 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new Markdown().Transform(sdType.Documentation[CurrentLanguage].Summary.ToString())));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t\t\t\t");
            
            #line 118 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t</tr>\r\n\r\n\t\t\t\t\t\t");
            
            #line 122 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t</tbody>\r\n\t\t\t\t</table>\r\n\t\t\t</div>\r\n\r\n\t\t\t");
            
            #line 128 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 if(Namespace.Uses.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<h3 class=\"box-title\">");
            
            #line 129 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.Uses));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\t\t\t\t<div class=\"list-box\">\r\n\t\t\t\t\t<ul>\r\n\t\t\t\t\t");
            
            #line 132 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 foreach(var use in Namespace.Uses) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<li><a href=\"../namespace/");
            
            #line 133 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(use.Fullname));
            
            #line default
            #line hidden
            this.Write(".html\">");
            
            #line 133 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(use.Fullname));
            
            #line default
            #line hidden
            this.Write("</a></li>\r\n\t\t\t\t\t");
            
            #line 134 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t</ul>\r\n\t\t\t\t</div>\r\n\t\t\t");
            
            #line 137 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 139 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 if(Namespace.UsedBy.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<h3 class=\"box-title\">");
            
            #line 140 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Strings.UsedBy));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\t\t\t\t<div class=\"list-box\">\r\n\t\t\t\t\t<ul>\r\n\t\t\t\t\t");
            
            #line 143 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 foreach(var used in Namespace.UsedBy) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<li><a href=\"../namespace/");
            
            #line 144 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(used.Fullname));
            
            #line default
            #line hidden
            this.Write(".html\">");
            
            #line 144 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(used.Fullname));
            
            #line default
            #line hidden
            this.Write("</a></li>\r\n\t\t\t\t\t");
            
            #line 145 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t</ul>\r\n\t\t\t\t</div>\r\n\t\t\t");
            
            #line 148 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t</div>\r\n\t   \r\n    </body>\r\n</html>\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 154 "D:\Github\SharpDox.Plugins.Html\Templates\Sites\NamespaceTemplate.tt"
 public IStrings Strings { get; set; }
	public string CurrentLanguage { get; set; }
	public SDRepository Repository { get; set; }
    public SDNamespace Namespace { get; set; } 
        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public class NamespaceTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
