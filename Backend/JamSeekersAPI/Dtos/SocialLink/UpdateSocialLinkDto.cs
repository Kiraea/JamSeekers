using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Dtos.SocialLink;

public class UpdateSocialLinkDto
{
    public int? Id { get; set; }  // Null = new link, non-null = update existing
    
    [Required]
    [Url]
    public string Url { get; set; }
    
    
    [Required]
    public int PlatformId { get; set; }
}