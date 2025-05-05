using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class City
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!; 
    
    [Required]
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    
    // nanivagiotn property btw
    public List<AppUser> AppUsers { get; set; } = [];
}