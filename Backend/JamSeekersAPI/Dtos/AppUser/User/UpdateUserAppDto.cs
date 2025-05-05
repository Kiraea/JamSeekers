using System.ComponentModel.DataAnnotations;
using JamSeekersAPI.Dtos.SocialLink;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Dtos.AppUser.User;

public class UpdateUserAppDto
{
    [MaxLength(30)]
    public string? DisplayName { get; set; } = null!;

    


    [MaxLength(250)]
    public string? BioDescription { get; set; }

    public int? CityId { get; set; }

    public List<int>? TagsToAdd { get; set; } = [];
    public List<int>? TagsToRemove { get; set; } = [];
    public List<int>? GenresToAdd { get; set; } = [];
    public List<int>? GenresToRemove { get; set; } = [];
    public List<UpdateSocialLinkDto>? SocialLinks { get; set; } = [];
    public List<int>? SocialLinksToRemove { get; set; } = [];
}