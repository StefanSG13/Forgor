namespace Forgor.Security.CQRS.Contracts.User.Dtos;

[ExcludeFromCodeCoverage]
public sealed class RegisterUserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
