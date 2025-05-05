using JamSeekersAPI.Models;

namespace JamSeekersAPI.Interfaces;

public interface IUserRepository
{
    Task<AppUser?> GetById(string id);
    Task<AppUser?> GetByIdWithTags(string userId);
}