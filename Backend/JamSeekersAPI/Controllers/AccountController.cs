using JamSeekersAPI.Dtos.AppUser;
using JamSeekersAPI.Models;
using JamSeekersAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JamSeekersAPI.Controllers;

[Route("/api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private readonly  SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;

    }

    [HttpPost("/register")]
    public async Task<IActionResult> Login([FromBody] CreateAppUserDto createAppUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("model is not valid");
        }

        var appUser = new AppUser
        {
            Email = createAppUserDto.Email,
            UserName = createAppUserDto.Email,
            DisplayName = createAppUserDto.DisplayName,
        };
        
       var createdUser = await _userManager.CreateAsync(appUser, createAppUserDto.Password);
      
       if (!createdUser.Succeeded) return BadRequest(createdUser.Errors.FirstOrDefault());
       
       var roles = await _userManager.AddToRoleAsync(appUser, "Member");
       if (roles.Succeeded)
       {
           return Ok(new NewUserDto
           {
               Email = createAppUserDto.Email,
               DisplayName = createAppUserDto.DisplayName,
               Token = _tokenService.GenerateToken(appUser)
           });
       }

       return BadRequest(createdUser.Errors.FirstOrDefault());
    }


    [HttpPost("/login")]
    public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
        if (user == null) return Unauthorized("Invalid email or password");

        var result = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        if (!result) return Unauthorized("Invalid email or password");
         
        var token = _tokenService.GenerateToken(user);
        return Ok(token);
        
    }
    

}