using JamSeekersAPI.Dtos.City;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class CityMapper
{
    public static CityDto ToCityDto(this City city)
    {
        return new CityDto
        {
            Id = city.Id,
            Name = city.Name,
        };
    }
}