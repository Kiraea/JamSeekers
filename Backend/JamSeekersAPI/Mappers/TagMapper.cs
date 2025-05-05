using JamSeekersAPI.Dtos.Tag;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Mappers;

public static class TagMapper
{
    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto
        {
            Id = tag.Id,
            Name = tag.Name,
        };
    }
}