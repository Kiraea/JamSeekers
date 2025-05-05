using System.Security.Claims;
using JamSeekersAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JamSeekersAPI.Controllers;


[Route("/api/[controller]")]
public class UserController : ControllerBase
{
   private readonly IUserService _userService;

   public UserController(IUserService userService)
   {
      _userService = userService;
   }

   [Authorize]
   [HttpGet("/me")]
   public async Task<IActionResult> Get()
   {
      var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

      if (id == null)
      {
         
         return Unauthorized(new {
            message = 
            "error check result DASDSADAS"
         });
      }

      var resultWrapper = await _userService.GetAppUserByIdAsync(id);
      if (!resultWrapper.IsSuccess)
      {
         return Unauthorized(new {
            message = 
               "error check FSAIDOSAIDOASDISA"
         });

      }
      
      return Ok(resultWrapper.Data);
   }
}