using JamSeekersAPI.Data;
using JamSeekersAPI.Interfaces;
using JamSeekersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JamSeekersAPI.Repositories;

public class GenreRepository : IGenreRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public GenreRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Genre>> GetGenresById(List<int> genreIds)
    {
        var genres = await _dbContext.Genres.Where(genre=> genreIds.Contains(genre.Id)).ToListAsync();
        return genres ;
    }
}