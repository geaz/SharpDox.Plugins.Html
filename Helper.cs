using SharpDox.Model.Repository;
using SharpDox.Model.Repository.Members;
using System;
using System.Collections.Generic;

namespace SharpDox.Plugins.Html
{
    public class Helper
    {
        private readonly SDRepository _repository;

        public Helper(SDRepository repository)
        {
            _repository = repository;
        }

        public string TransformLinkToken(string linkType, Guid guid, string identifier)
        {
            var link = string.Empty;
            if (linkType == "image")
            {
                link = string.Format("../assets/{0}s/{1}", linkType, identifier);
            }
            else if(linkType == "namespace")
            {
                link = string.Format("../{0}/{1}.html", linkType, identifier);
            }
            else if(linkType == "type")
            {
                var sdType = _repository.GetTypeByIdentifier(identifier);
                if(sdType != null)
                    link = string.Format("../{0}/{1}.html", "type", sdType.ShortIdentifier);
            }
            else if (guid != Guid.Empty) // Member
            {
                var sdMember = _repository.GetMemberByIdentifier(identifier);
                if (sdMember != null)
                    link = string.Format("../{0}/{1}.html#{2}", "type", sdMember.DeclaringType.ShortIdentifier, sdMember.ShortIdentifier);
            }
            else // Article
            {
                link = string.Format("../{0}/{1}.html", linkType, identifier);
            }
            return link;
        }
    }
}
