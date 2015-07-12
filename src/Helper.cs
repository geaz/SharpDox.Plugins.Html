using System;
using SharpDox.Model;
using SharpDox.Model.Repository;

namespace SharpDox.Plugins.Html
{
    public class Helper
    {
        private readonly SDProject _sdProject;

        public Helper(SDProject sdProject)
        {
            _sdProject = sdProject;
        }

        public string TransformLinkToken(string linkType, string identifier)
        {
            var link = string.Empty;
            if (linkType == "image")
            {
                link = string.Format("./data/{0}s/{1}", linkType, identifier);
            }
            else if(linkType == "namespace")
            {
                link = string.Format("#!{0}/{1}", linkType, identifier);
            }
            else if(linkType == "type")
            {
                link = string.Format("#!{0}/{1}", "type", identifier);
            }
            else if(linkType == "article")
            {
                link = string.Format("#!{0}/{1}", linkType, identifier);
            }
            else // Member
            {
                //var sdMember = _sdProject.GetMemberByIdentifier(identifier);
                //if (sdMember != null)
                //    link = string.Format("../{0}/{1}.html#{2}", "type", sdMember.DeclaringType.ShortIdentifier, sdMember.ShortIdentifier);
            }
            return link;
        }

        public string ToObjectString(string text)
        {
            var trimmedText = text.Trim();
            if (trimmedText.StartsWith("<pre><code>"))
            {
                trimmedText = trimmedText.Replace("<pre><code>", "");
                trimmedText = trimmedText.Replace("</code></pre>", "");
                trimmedText = trimmedText.Trim();
                trimmedText = string.Format("<pre><code class=\"language-csharp line-numbers\">{0}</code></pre>", trimmedText);
            }
            else if (trimmedText.Contains("<pre><code>"))
            {
                trimmedText = trimmedText.Replace("<pre><code>", "<pre><code class=\"language-csharp line-numbers\">");
                trimmedText = trimmedText.Replace(Environment.NewLine + "</code></pre>", "</code></pre>");
            }

            return trimmedText
                .Replace("\"", "\\\"")
                .Replace(Environment.NewLine, " \\n\\" + Environment.NewLine);
        }
    }
}
