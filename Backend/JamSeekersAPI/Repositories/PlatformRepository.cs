using JamSeekersAPI.Data;
using JamSeekersAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JamSeekersAPI.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly ApplicationDbContext _context;

    public PlatformRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> PlatformExists(int id)
    {
        return await _context.Platforms.AnyAsync(p => p.Id == id);
    }
}