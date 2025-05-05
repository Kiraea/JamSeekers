using JamSeekersAPI.Data;
using JamSeekersAPI.Interfaces;
using JamSeekersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JamSeekersAPI.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TagRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds)
    {
        var tags = await _dbContext.Tags.Where(tag => tagIds.Contains(tag.Id)).ToListAsync();

        return tags;
    }
}