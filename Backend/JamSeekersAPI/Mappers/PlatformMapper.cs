using JamSeekersAPI.Dtos.Platform;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class PlatformMapper
{
    public static PlatformDto ToPlatformDto(this Platform platform)
    {
        return new PlatformDto
        {
            Id = platform.Id,
            Name = platform.Name,
        };
    }
}