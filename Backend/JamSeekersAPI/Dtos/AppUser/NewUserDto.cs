namespace JamSeekersAPI.Dtos.AppUser;

public class NewUserDto
{
    public required string Email { get; set; } = null!;
    public required string DisplayName { get; set; } = null!;
    public required string Token { get; set; } = null!;
}