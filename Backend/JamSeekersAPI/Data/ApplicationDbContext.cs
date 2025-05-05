using JamSeekersAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JamSeekersAPI.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<UserGenre> UserGenres { get; set; }
    public DbSet<UserTag> UserTags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "1",
                NormalizedName = "ADMIN",
                Name = "Admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "2",
                NormalizedName = "MEMBER",
                Name = "Member",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            
        };

        var countries = new List<Country>
        {
            new Country { Id = 1, Name = "Philippines" },
            new Country { Id = 2, Name = "United States of America" },
        };
        var cities = new List<City>
        {
            new City { Id = 1, Name = "New York", CountryId = 2 },
            new City { Id = 2, Name = "Los Angeles", CountryId = 2 },
            new City { Id = 3, Name = "Austin", CountryId = 2 },
            new City { Id = 4, Name = "Davao", CountryId = 1 },
            new City { Id = 5, Name = "Las Pinas", CountryId = 1 },
            new City { Id = 6, Name = "Batangas", CountryId = 1 },
            new City { Id = 7, Name = "Quezon", CountryId = 1 },
            new City { Id = 8, Name = "Pasig", CountryId = 1 },
        };
        var tags = new List<Tag>
        {
            new Tag { Id = 1, Name = "Pianist" },
            new Tag { Id = 2, Name = "Bassist" },
            new Tag { Id = 3, Name = "Trombonist" },
            new Tag { Id = 4, Name = "Flutist" },
            new Tag { Id = 5, Name = "Guitarist" },
            new Tag { Id = 6, Name = "Drummer" },
            new Tag { Id = 7, Name = "Producer" },
            new Tag { Id = 8, Name = "Songwriter" },
            new Tag { Id = 9, Name = "Vocalist" },
            new Tag { Id = 10, Name = "Rapper" },
            new Tag { Id = 11, Name = "DJ" },
            new Tag { Id = 12, Name = "Audio Engineer" },
            new Tag { Id = 13, Name = "Violinist" },
            new Tag { Id = 14, Name = "Cellist" },
            new Tag { Id = 15, Name = "Saxophonist" },
            new Tag { Id = 16, Name = "Trumpeter" },
            new Tag { Id = 17, Name = "Clarinetist" },
            new Tag { Id = 18, Name = "Composer" },
            new Tag { Id = 19, Name = "Arranger" },
            new Tag { Id = 20, Name = "Conductor" },
            new Tag { Id = 21, Name = "Lyricist" },
            new Tag { Id = 22, Name = "Percussionist" },
            new Tag { Id = 23, Name = "Synth Player" },
            new Tag { Id = 24, Name = "Beatmaker" },
            new Tag { Id = 25, Name = "Live Performer" }
        };
        var genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Pop" },
            new Genre { Id = 2, Name = "Rock" },
            new Genre { Id = 3, Name = "Hip-Hop" },
            new Genre { Id = 4, Name = "Jazz" },
            new Genre { Id = 5, Name = "Classical" },
            new Genre { Id = 6, Name = "R&B" },
            new Genre { Id = 7, Name = "Reggae" },
            new Genre { Id = 8, Name = "Blues" },
            new Genre { Id = 9, Name = "Electronic" },
            new Genre { Id = 10, Name = "Country" },
            new Genre { Id = 11, Name = "Funk" },
            new Genre { Id = 12, Name = "Soul" },
            new Genre { Id = 13, Name = "Gospel" },
            new Genre { Id = 14, Name = "Latin" },
            new Genre { Id = 15, Name = "K-Pop" },
            new Genre { Id = 16, Name = "Indie" },
            new Genre { Id = 17, Name = "Metal" },
            new Genre { Id = 18, Name = "Alternative" },
            new Genre { Id = 19, Name = "House" },
            new Genre { Id = 20, Name = "Techno" }
        };
        var platforms = new List<Platform>
        {
            new Platform { Id = 1, Name = "Facebook" },
            new Platform { Id = 2, Name = "Twitter" },
            new Platform { Id = 3, Name = "Spotify" },
            new Platform { Id = 4, Name = "SoundCloud" },
            new Platform { Id = 4, Name = "Instagram" },
            new Platform { Id = 4, Name = "Tiktok" },
            new Platform { Id = 4, Name = "Youtube" },
        };

        modelBuilder.Entity<UserGenre>().HasKey(entry => new { entry.UserId, entry.GenreId });
        modelBuilder.Entity<UserTag>().HasKey(entry => new { entry.UserId, entry.TagId});
        
        modelBuilder.Entity<Country>().HasData(countries);
        modelBuilder.Entity<City>().HasData(cities);
        modelBuilder.Entity<Tag>().HasData(tags);
        modelBuilder.Entity<Genre>().HasData(genres);
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}