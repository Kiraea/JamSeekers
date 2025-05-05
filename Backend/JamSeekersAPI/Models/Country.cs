using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class Country
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    
    public List<City> Cities { get; set; } = [];
}