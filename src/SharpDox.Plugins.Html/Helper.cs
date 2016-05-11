using System.Linq;
using System.Text.RegularExpressions;
using SharpDox.Model;

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
                link = $"./data/{linkType}s/{identifier}";
            }
            else if(linkType == "namespace")
            {
                link = $"#/{linkType}/{identifier}";
            }
            else if(linkType == "type")
            {
                link = $"#/{linkType}/{identifier.RemoveIllegalPathChars()}";
            }
            else if(linkType == "article")
            {
                link = $"#/{linkType}/{identifier}";
            }
            else // Member
            {
                var identifierWithoutPrefix = identifier
                    .Replace("field.", "")
                    .Replace("event.", "")
                    .Replace("property.", "");

                var regEx = new Regex(@"\.(?![^\(]*\))");
                var splittedId = regEx.Split(identifierWithoutPrefix);
                link = $"#/type/{string.Join(".", splittedId.Take(splittedId.Length - 1)).Trim('.')}/{identifier}".RemoveIllegalPathChars();
            }
            return link;
        }
    }
}
