using JamSeekersAPI.Dtos.Platform;
using JamSeekersAPI.Dtos.SocialLink;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class SocialLinkMapper
{
    public static SocialLinkDto ToSocialLinkDto(this SocialLink socialLink)
    {
       return new SocialLinkDto
       {
           Id = socialLink.Id,
           Url = socialLink.Url,
           PlatformDto = new PlatformDto
           {
               Id = socialLink.Platform.Id,
               Name = socialLink.Platform.Name
           },
           PlatformId = socialLink.Platform.Id
       }; 
    }
}