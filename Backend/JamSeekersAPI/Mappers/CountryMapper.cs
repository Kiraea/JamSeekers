using JamSeekersAPI.Dtos.Country;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class CountryMapper
{
    public static CountryDto ToCountryDto(this Country country)
    {
        return new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
        };
    }
}