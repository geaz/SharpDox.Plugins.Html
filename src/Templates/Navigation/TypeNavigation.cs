﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 12.0.0.0
//  
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SharpDox.Plugins.Html.Templates.Navigation
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using SharpDox.Model.Repository;
    using SharpDox.Plugins.Html.Steps;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class TypeNavigation : TypeNavigationBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write(" \r\n");
            this.Write("\r\n");
            
            #line 10 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 if(Type.Fields.Count > 0){ 
            
            #line default
            #line hidden
            this.Write("\t{\r\n\t\tid: \'");
            
            #line 12 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ttext: \'");
            
            #line 13 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StepInput.HtmlStrings.Fields));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ticon: \'icon-folder-close\',\r\n\t\tchildren: [\r\n\t\t\t");
            
            #line 16 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 foreach(var sdField in Type.Fields) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tid: \'");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdField.Identifier));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ttext: \'");
            
            #line 19 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdField.Name));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ticon: \'./assets/icons/field_");
            
            #line 20 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdField.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\',\r\n\t\t\t\ta_attr: { href : \'#!member/");
            
            #line 21 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdField.Identifier));
            
            #line default
            #line hidden
            this.Write("\' },\r\n\t\t\t},\r\n\t\t\t");
            
            #line 23 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t]\r\n\t},\r\n");
            
            #line 26 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 28 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 if(Type.Constructors.Count > 0){ 
            
            #line default
            #line hidden
            this.Write("\t{\r\n\t\tid: \'");
            
            #line 30 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ttext: \'");
            
            #line 31 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StepInput.HtmlStrings.Constructors));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ticon: \'icon-folder-close\',\r\n\t\tchildren: [\r\n\t\t\t");
            
            #line 34 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 foreach(var sdConstructor in Type.Constructors) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tid: \'");
            
            #line 36 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdConstructor.Identifier));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ttext: \'");
            
            #line 37 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdConstructor.Name));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ticon: \'./assets/icons/method_");
            
            #line 38 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdConstructor.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\',\r\n\t\t\t\ta_attr: { href : \'#!member/");
            
            #line 39 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdConstructor.Identifier));
            
            #line default
            #line hidden
            this.Write("\' },\r\n\t\t\t},\r\n\t\t\t");
            
            #line 41 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t]\r\n\t},\r\n");
            
            #line 44 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 46 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 if(Type.Methods.Count > 0){ 
            
            #line default
            #line hidden
            this.Write("\t{\r\n\t\tid: \'");
            
            #line 48 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ttext: \'");
            
            #line 49 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StepInput.HtmlStrings.Methods));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ticon: \'icon-folder-close\',\r\n\t\tchildren: [\r\n\t\t\t");
            
            #line 52 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 foreach(var sdMethod in Type.Methods) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tid: \'");
            
            #line 54 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdMethod.Identifier));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ttext: \'");
            
            #line 55 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdMethod.Name));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ticon: \'./assets/icons/method_");
            
            #line 56 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdMethod.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\',\r\n\t\t\t\ta_attr: { href : \'#!member/");
            
            #line 57 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdMethod.Identifier));
            
            #line default
            #line hidden
            this.Write("\' },\r\n\t\t\t},\r\n\t\t\t");
            
            #line 59 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t]\r\n\t},\r\n");
            
            #line 62 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 64 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 if(Type.Events.Count > 0){ 
            
            #line default
            #line hidden
            this.Write("\t{\r\n\t\tid: \'");
            
            #line 66 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ttext: \'");
            
            #line 67 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StepInput.HtmlStrings.Events));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ticon: \'icon-folder-close\',\r\n\t\tchildren: [\r\n\t\t\t");
            
            #line 70 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 foreach(var sdEvent in Type.Events) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tid: \'");
            
            #line 72 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdEvent.Identifier));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ttext: \'");
            
            #line 73 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdEvent.Name));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ticon: \'./assets/icons/event_");
            
            #line 74 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdEvent.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\',\r\n\t\t\t\ta_attr: { href : \'#!member/");
            
            #line 75 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdEvent.Identifier));
            
            #line default
            #line hidden
            this.Write("\' },\r\n\t\t\t},\r\n\t\t\t");
            
            #line 77 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t]\r\n\t},\r\n");
            
            #line 80 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 82 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 if(Type.Properties.Count > 0){ 
            
            #line default
            #line hidden
            this.Write("\t{\r\n\t\tid: \'");
            
            #line 84 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ttext: \'");
            
            #line 85 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(StepInput.HtmlStrings.Properties));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\ticon: \'icon-folder-close\',\r\n\t\tchildren: [\r\n\t\t\t");
            
            #line 88 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 foreach(var sdProperty in Type.Properties) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tid: \'");
            
            #line 90 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdProperty.Identifier));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ttext: \'");
            
            #line 91 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdProperty.Name));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\ticon: \'./assets/icons/property_");
            
            #line 92 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdProperty.Accessibility));
            
            #line default
            #line hidden
            this.Write(".png\',\r\n\t\t\t\ta_attr: { href : \'#!member/");
            
            #line 93 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdProperty.Identifier));
            
            #line default
            #line hidden
            this.Write("\' },\r\n\t\t\t},\r\n\t\t\t");
            
            #line 95 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t]\r\n\t},\r\n");
            
            #line 98 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 100 "D:\Github\SharpDox.Plugins.Html\src\Templates\Navigation\TypeNavigation.tt"
	public SDType Type { get; set; } 
        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class TypeNavigationBase
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