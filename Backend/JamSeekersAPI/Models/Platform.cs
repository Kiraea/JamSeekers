using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class Platform
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}