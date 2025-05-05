namespace JamSeekersAPI.Models;

public class UserGenre
{
    public string UserId { get; set; }
    public AppUser User { get; set; } = null!;


    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
}