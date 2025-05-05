using System.ComponentModel.DataAnnotations;

namespace JamSeekersAPI.Models;

public class UserTag
{
    
    public string UserId { get; set; } // the reason why no required is ef already knows thisand besdies int can not nullable
    [Required] public AppUser User { get; set; } = null!; // for null idk but this needs required cause objects is nullable
    
    public int TagId { get; set; }
    [Required] public Tag Tag { get; set; } = null!;

}