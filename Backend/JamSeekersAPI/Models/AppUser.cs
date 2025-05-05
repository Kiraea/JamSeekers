using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JamSeekersAPI.Models;

public class AppUser : IdentityUser
{ 
   [MaxLength(250)] 
   public string? BioDescription { get; set; }
   
   [MaxLength(50)]
   public string? DisplayName { get; set; }
   



   public List<UserGenre> UserGenres { get; set; } = [];  // list because user can have genres 
   public List<UserTag> UserTags { get; set; } = [];  
   public List<SocialLink> SocialLinks { get; set; } = []; 
   
   
   
   public int? CityId { get; set; } 
   public City? City { get; set; } = null!;
   
}


/*
public ICollection<SocialLink> SocialLinks { get; set; } // ← not initialized
Then this code breaks:

csharp
Copy
Edit
user.SocialLinks.Add(...); // ❌ NullReferenceException if user was just created
You now have to write:

csharp
Copy
Edit
if (user.SocialLinks == null)
    user.SocialLinks = new List<SocialLink>();
*/