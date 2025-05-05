using JamSeekersAPI.Dtos.Country;

namespace JamSeekersAPI.Dtos.City;

public class CityDto
{
    
    public int Id { get; set; }
    public string Name { get; set; } = null!;
   
    public int CountryId { get; set; }
    public CountryDto CountryDto { get; set; } = null!;
}