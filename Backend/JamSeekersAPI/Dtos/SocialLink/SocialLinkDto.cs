using System.ComponentModel.DataAnnotations;
using JamSeekersAPI.Dtos.Platform;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Dtos.SocialLink;

public class SocialLinkDto
{
    public int Id { get; set; }
   
    [Required]
    public string Url { get; set; } = null!;

    public int PlatformId { get; set; } 
    
    [Required]
    public PlatformDto PlatformDto { get; set; } = null!;
    
    
}