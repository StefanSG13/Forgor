using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Handlers.ValidationExtensions.User;

internal static class RegisterUserDtoValidation
{
    internal static List<string> Validate(this RegisterUserDto dto)
    {
        var errors = new List<string>();

        if (dto is null)
        {
            errors.Add("Dto is null");
            return errors;
        }

        if (!CommonValidations.IsNameValid(dto.FirstName))
            errors.Add("First name is invalid");

        if(!CommonValidations.IsNameValid(dto.LastName))
            errors.Add("Last name is invalid");

        if (!CommonValidations.IsNameValid(dto.MiddleName))
            errors.Add("Middle name is invalid");

        if (CommonValidations.IsEmailValid(dto.Email))
            errors.Add("Email is invalid");

        if (!CommonValidations.IsPasswordValid(dto.Password))
            errors.Add("Password is invalid");

        if(!CommonValidations.IsPhoneNumberValid(dto.PhoneNumber))
            errors.Add("Phone number is invalid");

        if(!CommonValidations.IsDateOfBirthValid(dto.DateOfBirth))
            errors.Add("Date of birth is invalid");

        return errors;
    }
}
