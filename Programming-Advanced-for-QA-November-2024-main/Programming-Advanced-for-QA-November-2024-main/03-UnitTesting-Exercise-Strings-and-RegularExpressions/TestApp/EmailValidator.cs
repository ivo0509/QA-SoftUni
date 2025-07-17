using System.Text.RegularExpressions;

namespace TestApp;

public class EmailValidator
{
    public static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new(pattern);

        return regex.IsMatch(email);
    }
}
