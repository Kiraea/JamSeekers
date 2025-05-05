using JamSeekersAPI.Dtos.AppUser.User;
using JamSeekersAPI.Dtos.City;
using JamSeekersAPI.Dtos.Country;
using JamSeekersAPI.Dtos.Genre;
using JamSeekersAPI.Dtos.Platform;
using JamSeekersAPI.Dtos.SocialLink;
using JamSeekersAPI.Dtos.Tag;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class AppUserMapper
{
    public static AppUserDto FromAppUserToAppUserDto(this AppUser appUser)
    {
        return new AppUserDto
        {
            // Map scalar properties directly
            
            City = appUser.City?.ToCityDto(),
            Email = appUser.Email!,
            BioDescription = appUser.BioDescription,
            
            Genres = appUser.UserGenres.Select(g=>g.Genre.ToGenreDto()).ToList(),
            Tags = appUser.UserTags.Select(t => t.Tag.ToTagDto()).ToList(),
            
            SocialLinks = appUser.SocialLinks.Select(s => s.ToSocialLinkDto()).ToList(),
        };
    }

}