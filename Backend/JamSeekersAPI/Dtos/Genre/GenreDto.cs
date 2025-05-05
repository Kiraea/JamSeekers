using System.ComponentModel.DataAnnotations;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Dtos.Genre;

public class GenreDto
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    // the null means ou're telling the compiler, "Trust me, this will be initialized by something else before it's used" (like EF Core loading data or model binding setting the value).

    
    //public List<UserGenre> UserGenres { get; set; } = []; 
    
}