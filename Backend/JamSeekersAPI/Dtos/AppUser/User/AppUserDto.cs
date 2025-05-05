using System.ComponentModel.DataAnnotations;
using JamSeekersAPI.Dtos.City;
using JamSeekersAPI.Dtos.Country;
using JamSeekersAPI.Dtos.Genre;
using JamSeekersAPI.Dtos.SocialLink;
using JamSeekersAPI.Dtos.Tag;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Dtos.AppUser.User;

public class AppUserDto
{
    [Required] 
    [MaxLength(30)]
    public string DisplayName { get; set; } = null!;
    
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    
    
    [MaxLength(250)]
    public string? BioDescription { get; set; }
    
    
    
    public CityDto? City { get; set; }
    
    public List<TagDto> Tags{ get; set; } = [];
    public List<GenreDto> Genres { get; set; } = [];
    public List<SocialLinkDto> SocialLinks { get; set; } = [];
}