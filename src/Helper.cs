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
            /*if (linkType == "image")
            {
                link = string.Format("../assets/{0}s/{1}", linkType, identifier);
            }
            else if(linkType == "namespace")
            {
                link = string.Format("../{0}/{1}.html", linkType, identifier);
            }
            else if(linkType == "type")
            {
                var sdType = _sdProject.GetTypeByIdentifier(identifier);
                if(sdType != null)
                    link = string.Format("../{0}/{1}.html", "type", sdType.ShortIdentifier);
            }
            else if(linkType == "article")
            {
                link = string.Format("../{0}/{1}.html", linkType, identifier);
            }
            else // Member
            {
                var sdMember = _sdProject.GetMemberByIdentifier(identifier);
                if (sdMember != null)
                    link = string.Format("../{0}/{1}.html#{2}", "type", sdMember.DeclaringType.ShortIdentifier, sdMember.ShortIdentifier);
            }*/
            return link;
        }
    }
}
