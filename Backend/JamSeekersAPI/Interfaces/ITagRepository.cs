using JamSeekersAPI.Models;

namespace JamSeekersAPI.Interfaces;

public interface ITagRepository
{

    public Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds);
}