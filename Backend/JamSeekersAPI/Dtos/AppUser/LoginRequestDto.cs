using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Dtos.AppUser;

public class LoginRequestDto
{
    [Required]
    public required string Email { get; set; } 
    
    
    [Required]
    public required string Password { get; set; } 
}