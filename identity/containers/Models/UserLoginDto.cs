namespace Easyfood.Identity.Models;

public record UserLoginDto
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}