﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion: 14.0.0.0
//  
//     Änderungen an dieser Datei können fehlerhaftes Verhalten verursachen und gehen verloren, wenn
//     der Code neu generiert wird.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SharpDox.Plugins.Html.Templates.Repository
{
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Collections.Generic;
    using SharpDox.Model;
    using SharpDox.Model.Documentation;
    using SharpDox.Model.Documentation.Token;
    using SharpDox.Model.Documentation.Article;
    using SharpDox.Plugins.Html.Steps;
    using CommonMark;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\DocumentationData.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DocumentationData : DocumentationDataBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 15 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\DocumentationData.tt"
 var helper = new Helper(StepInput.SDProject);

var documentation = new List<string>();
if(Documentation.Summary.Count > 0) {
	documentation.Add(string.Format("\"summary\":\"{0}\"", CommonMarkConverter.Convert(Documentation.Summary.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString()));
} 
if(Documentation.Remarks.Count > 0) {
	documentation.Add(string.Format("\"remarks\":\"{0}\"", CommonMarkConverter.Convert(Documentation.Remarks.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString()));
}
if(Documentation.Example.Count > 0) {
	documentation.Add(string.Format("\"example\":\"{0}\"", CommonMarkConverter.Convert(Documentation.Example.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString()));
}
if(Documentation.Returns.ContainsKey("default")) {
	documentation.Add(string.Format("\"returns\":\"{0}\"", CommonMarkConverter.Convert(Documentation.Returns["default"].ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString()));
}
if(Documentation.Exceptions.Count > 0) {
	documentation.Add(string.Format("\"exceptions\":[{0}]", 
				string.Join(",", Documentation.Exceptions.Select(exception => 
					string.Format("{{\"key\": \"{0}\",\"value\": \"{1}\"}}", exception.Key, 
					CommonMarkConverter.Convert(exception.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString())))));
}
if(Documentation.Params.Count > 0) {
	documentation.Add(string.Format("\"params\":[{0}]", 
				string.Join(",", Documentation.Params.Select(param => 
					string.Format("{{\"key\": \"{0}\",\"value\": \"{1}\"}}", param.Key, 
					CommonMarkConverter.Convert(param.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString())))));
}
if(Documentation.TypeParams.Count > 0) {
	documentation.Add(string.Format("\"params\":[{0}]", 
				string.Join(",", Documentation.TypeParams.Select(typeParam => 
					string.Format("{{\"key\": \"{0}\",\"value\": \"{1}\"}}", typeParam.Key, 
					CommonMarkConverter.Convert(typeParam.Value.ToMarkdown(StepInput.SDProject.Tokens).Transform(helper.TransformLinkToken)).ToObjectString())))));	
}
if(Documentation.SeeAlsos.Count > 0 ){
	var seeAlsos = new List<string>();
	foreach(var sdToken in Documentation.SeeAlsos){
		var seeAlso = (SDSeeToken)sdToken;
		if(!string.IsNullOrEmpty(seeAlso.DeclaringType))
		{
			var identifier = string.Format("{0}.{1}", seeAlso.DeclaringType, seeAlso.Name);
			seeAlsos.Add(string.Format("{{\"type\":\"\", \"id\":\"{0}\", \"name\":\"{1}\"}}", identifier, seeAlso.Name));
        }
		else
		{
			var identifier = string.Format("{0}.{1}", seeAlso.Namespace, seeAlso.Name);
			seeAlsos.Add(string.Format("{{\"type\":\"\", \"id\":\"{0}\", \"name\":\"{1}\"}}", identifier, seeAlso.Name)); 
		} 	
    }
	documentation.Add(string.Format("\"seeAlsos\":[{0}]", string.Join(",", seeAlsos)));
} 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 66 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\DocumentationData.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(",", documentation) + ","));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 69 "D:\Github\SharpDox.Plugins.Html\src\Templates\Repository\DocumentationData.tt"
	public SDDocumentation Documentation { get; set; } 
        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class DocumentationDataBase
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
