using JamSeekersAPI.Dtos.Genre;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class GenreMapper
{
    public static GenreDto ToGenreDto(this Genre genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
}