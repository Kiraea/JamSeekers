using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Dtos.AppUser;

public class CreateAppUserDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; } 
    [Required]
    
    [StringLength(maximumLength: 40, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 40 characters long.")]
    public required string Password { get; set; }
    
    
    [Required]
    [MaxLength(30)]
    public required string DisplayName { get; set; }
}