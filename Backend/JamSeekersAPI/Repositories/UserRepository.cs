using JamSeekersAPI.Data;
using JamSeekersAPI.Interfaces;
using JamSeekersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JamSeekersAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppUser?> GetById(string id)
    {
        var appUser = await _dbContext.Users
                // gets the include first gets the user tage Id but no tages the then include actually includes the tag now
            .Include(u => u.UserTags).ThenInclude(ut => ut.Tag)
            .Include(u => u.UserGenres).ThenInclude(ug => ug.Genre)
            .Include(u => u.SocialLinks)
            .Include(u => u.City)
            .FirstOrDefaultAsync(u => u.Id == id);

        return appUser;
    }


    public async Task<AppUser?> GetByIdWithTags(string id)
    {
        var appUser = await _dbContext.Users.Include(u => u.UserTags).FirstOrDefaultAsync((u) => u.Id == id);
        return appUser;
    }


    public async Task<AppUser?> GetByIdWithSocialLinks(string id)
    {
        var appUser = await _dbContext.Users.Include(u => u.SocialLinks).FirstOrDefaultAsync((u) => u.Id == id);
        return appUser;
    }


    /*
     *
     *
     public async Task<bool> UserHasTagAsync(string userId, int tagId)
     {
         return await _dbContext.Users.AnyAsync(u => u.Id == userId && u.Tags.Any(t => t.Id == tagId));
     }


     public async Task RemoveTagsFromUserAsync(string userId, List<int> tagIds)
     {
         await _dbContext.UserTags.Where(ut => ut.UserId == userId && tagIds.Contains(ut.TagId)).ExecuteDeleteAsync();
     }
     *
     *
     */


    /*
     *
     *
        var user = await GetByIdWithTags(userId);
        if (user == null)
        {
            return null;
        }

        var validTags = tags.Where((t) => !user.Tags.Any((userT) => userT.Id == t.Id));
        user.Tags.AddRange(validTags);
        await _dbContext.SaveChangesAsync();
        return user;
     *
     *
     *
        var user = await GetByIdWithTags(userId);
        if (user == null)
        {
            return null;
        }
        var validTags = tags.Where((t)=> user.Tags.Any(ut => ut.Id == t.Id)).ToList();
        user.Tags.RemoveRange(validTags, validTags.Count);
     *
     */
}