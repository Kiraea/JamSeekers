using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JamSeekersAPI.Controllers;
using JamSeekersAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace JamSeekersAPI.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]!));
    }

    public string GenerateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.GivenName, user.Email!),
            // if were gonna make it custom i
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            
        };
        
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
            Expires = DateTime.Now.AddMinutes(30),
        };

        var token = tokenHandler.CreateToken(securityTokenDescriptor);
        return tokenHandler.WriteToken(token);
        
    }


}