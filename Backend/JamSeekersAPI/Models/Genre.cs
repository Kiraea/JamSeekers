using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class Genre
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    // the null means ou're telling the compiler, "Trust me, this will be initialized by something else before it's used" (like EF Core loading data or model binding setting the value).

    
    public List<UserGenre> UserGenres { get; set; } = []; 
}