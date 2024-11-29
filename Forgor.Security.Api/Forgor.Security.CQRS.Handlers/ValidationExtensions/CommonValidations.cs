namespace Forgor.Security.CQRS.Handlers.ValidationExtensions;

internal static class CommonValidations
{
    internal static bool IsEmailValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }

    internal static bool IsPasswordValid(string password)
    {
        return true;
        if (string.IsNullOrWhiteSpace(password))
            return false;

        var passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
        return System.Text.RegularExpressions.Regex.IsMatch(password, passwordPattern);
    }

    internal static bool IsNameValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var namePattern = @"^[a-zA-Z\s\-']+$";
        if (!System.Text.RegularExpressions.Regex.IsMatch(name, namePattern))
            return false;

        if (name.Length < 2 || name.Length > 50)
            return false;

        return true;
    }

    internal static bool IsPhoneNumberValid(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        // Remove any non-digit characters
        var digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

        if (digitsOnly.Length < 10 || digitsOnly.Length > 15)
            return false;

        var phonePattern = @"^\+?(\d{1,3})?[-.\s]?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$";
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, phonePattern);
    }

    internal static bool IsDateOfBirthValid(DateTime dateOfBirth)
    {
        var minDate = new DateTime(1900, 1, 1);
        var maxDate = DateTime.Now.AddYears(-16);

        if (dateOfBirth < minDate || dateOfBirth > maxDate)
            return false;

        return true;
    }
}
