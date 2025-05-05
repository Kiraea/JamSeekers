using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Dtos.Platform;

public class PlatformDto
{
    
    public int Id { get; set; }
    [Required] public string Name { get; set; } = null!;

};