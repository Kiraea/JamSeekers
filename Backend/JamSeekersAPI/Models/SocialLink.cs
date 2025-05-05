using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class SocialLink
{
    public int Id { get; set; }
   
    [Required]
    public string Url { get; set; }
    
    
    public int PlatformId { get; set; }
    
    [Required]
    public Platform Platform { get; set; } = null!;
    
    
    public string UserId { get; set; }
    [Required]
    public AppUser User { get; set; }   = null!;
}