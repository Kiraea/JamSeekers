using JamSeekersAPI.Dtos.AppUser.User;
using JamSeekersAPI.Models;

namespace JamSeekersAPI.Interfaces;

public interface IUserService
{
   Task<ResultWrapper<List<AppUserDto>>> GetAppUsersAsync(); 
   Task<ResultWrapper<AppUserDto>> GetAppUserByIdAsync(string id); 
   Task<ResultWrapper<AppUser>> UpdateAppUserAsync(string id, UpdateUserAppDto updateUserAppDto);
   
   
}