namespace JamSeekersAPI.Models;

public class Tag
{
   public int Id { get; set; }
   public required string Name { get; set; }
   public List<UserTag> UserTags { get; set; } = [];
}