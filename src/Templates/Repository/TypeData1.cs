﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 12.0.0.0
//  
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SharpDox.Plugins.Html.Templates.Repository
{
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Collections.Generic;
    using SharpDox.Model;
    using SharpDox.Model.Documentation.Token;
    using SharpDox.Model.Documentation.Article;
    using SharpDox.Plugins.Html.Steps;
    using CommonMark;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class TypeData : TypeDataBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 14 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 var helper = new Helper(StepInput.SDProject); 
            
            #line default
            #line hidden
            this.Write("\r\nvar sharpDox = sharpDox || {};\r\n\r\nsharpDox.typeData = {\n\t");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var sdSolution in StepInput.SDProject.Solutions)
	{
		foreach(var sdTargetTypeDic in sdSolution.Value.GetAllTypes())
		{ 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\n\t\t\t\"");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdTargetTypeDic.Key));
            
            #line default
            #line hidden
            this.Write("\": {\n\t\t\t\n\t\t\t");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var sdTargetType in sdTargetTypeDic.Value)
            {
				var sdType = sdTargetType.Value;
				var targetFx = sdTargetType.Key; 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\n\t\t\t\t\"");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(targetFx.Name));
            
            #line default
            #line hidden
            this.Write("\": {\n\t\t\t\t\tname: \"");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Name));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\tnamespace: \"");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Namespace.Fullname));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\tsyntax: \"");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sdType.Syntax));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\tbaseTypes: [\n\t\t\t\t\t\t");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var baseType in sdType.BaseTypes) { 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t\t{\n\t\t\t\t\t\t\t");
            
            #line 18 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 if(!baseType.IsProjectStranger) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\tid: \"");
            
            #line 19 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(baseType.Identifier));
            
            #line default
            #line hidden
            this.Write("\",\t\r\n\t\t\t\t\t\t\t");
            
            #line 20 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\tname: \"");
            
            #line 21 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(baseType.Fullname));
            
            #line default
            #line hidden
            this.Write("\"\t\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t");
            
            #line 23 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t],\n\t\t\t\t\timplements: [\n\t\t\t\t\t\t");
            
            #line 24 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var implementedInterface in sdType.ImplementedInterfaces) { 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t\t{\n\t\t\t\t\t\t\t");
            
            #line 24 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 if(!implementedInterface.IsProjectStranger) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\tid: \"");
            
            #line 25 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(implementedInterface.Identifier));
            
            #line default
            #line hidden
            this.Write("\",\t\r\n\t\t\t\t\t\t\t");
            
            #line 26 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\tname: \"");
            
            #line 27 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(implementedInterface.Fullname));
            
            #line default
            #line hidden
            this.Write("\"\t\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\n\t\t\t\t\t],\n\t\t\t\t\t");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 var documentation = sdType.Documentations.GetElementOrDefault(StepInput.CurrentLanguage);
					if(documentation != null){ 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\tsummary: \"");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(documentation.Summary.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\t\tremarks: \"");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(documentation.Remarks.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\t\texample: \"");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(documentation.Example.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\t\t");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 if(documentation.Returns.ContainsKey("default")) { 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t\treturns: \"");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(documentation.Returns["default"].ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\",\n\t\t\t\t\t\t");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\texceptions: [\n\t\t\t\t\t\t\t");
            
            #line 29 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var exception in documentation.Exceptions) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\tkey: \"");
            
            #line 31 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(exception.Key));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t\t\t\t\tvalue: \"");
            
            #line 32 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(exception.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\" \r\n\t\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\t");
            
            #line 33 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t],\n\t\t\t\t\t\tparams: [\n\t\t\t\t\t\t\t");
            
            #line 33 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var param in documentation.Params) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\tkey: \"");
            
            #line 35 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(param.Key));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t\t\t\t\tvalue: \"");
            
            #line 36 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(param.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\" \r\n\t\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\t");
            
            #line 37 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t],\n\t\t\t\t\t\ttypeParams: [\n\t\t\t\t\t\t\t");
            
            #line 37 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var typeParam in documentation.TypeParams) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\tkey: \"");
            
            #line 39 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(typeParam.Key));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t\t\t\t\tvalue: \"");
            
            #line 40 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(helper.ToObjectString(CommonMarkConverter.Convert(typeParam.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)))));
            
            #line default
            #line hidden
            this.Write("\" \r\n\t\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\t");
            
            #line 41 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\n\t\t\t\t\t\t],\n\t\t\t\t\t\tseeAlsos: [\n\t\t\t\t\t\t\t");
            
            #line 41 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 foreach(var sdToken in documentation.SeeAlsos) 
							{ 
								var seeAlso = (SDSeeToken)sdToken;
								if(!string.IsNullOrEmpty(seeAlso.DeclaringType))
								{
									var identifier = string.Format("{0}.{1}", seeAlso.DeclaringType, seeAlso.Name); 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\t\ttype: \"\",\r\n\t\t\t\t\t\t\t\t\t\tid: \"");
            
            #line 49 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(identifier));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t\t\t\t\t\tname: \"");
            
            #line 50 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(seeAlso.Name));
            
            #line default
            #line hidden
            this.Write("\"\r\n\t\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\t");
            
            #line 52 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 }
								else
								{
									var identifier = string.Format("{0}.{1}", seeAlso.Namespace, seeAlso.Name); 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\t\ttype: \"\",\r\n\t\t\t\t\t\t\t\t\t\tid: \"");
            
            #line 58 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(identifier));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t\t\t\t\t\tname: \"");
            
            #line 59 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(seeAlso.Name));
            
            #line default
            #line hidden
            this.Write("\"\r\n\t\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\t");
            
            #line 61 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
							} 
            
            #line default
            #line hidden
            this.Write("\n\t\t\t\t\t\t],\n\t\t\t\t\t");
            
            #line 62 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n\n\t\t\t\t},\n\t\t\t},\n\t\t\t");
            
            #line 62 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\TypeData.tt"
 }
		}
	} 
            
            #line default
            #line hidden
            this.Write("\n};");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class TypeDataBase
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