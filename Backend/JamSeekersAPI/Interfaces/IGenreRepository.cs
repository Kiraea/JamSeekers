using JamSeekersAPI.Models;

namespace JamSeekersAPI.Interfaces;

public interface IGenreRepository
{

    public Task<List<Genre>> GetGenresById(List<int> genreIds);
}