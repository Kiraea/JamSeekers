using JamSeekersAPI.Models;

namespace JamSeekersAPI.Controllers;

public interface ITokenService
{
    string GenerateToken(AppUser user);
}