namespace Easyfood.Identity.Models;

public record UserRegisterDto(string UserName,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    DateTime BirthDate);