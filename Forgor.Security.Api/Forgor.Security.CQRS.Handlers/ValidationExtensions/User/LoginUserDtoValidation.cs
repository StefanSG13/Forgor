using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Handlers.ValidationExtensions.User;

internal static class LoginUserDtoValidation
{
    internal static List<string> Validate(this LoginUserDto dto)
    {
        var errors = new List<string>();

        if (dto is null)
            errors.Add("User is null");

        if (!CommonValidations.IsEmailValid(dto.Email))
            errors.Add("Email is invalid");

        if (!CommonValidations.IsPasswordValid(dto.Password))
            errors.Add("Password is invalid");

        return errors;
    }
}
