using System.Net.Mail;

namespace TestApp;

public class Email
{
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return MailAddress.TryCreate(email, out _);
    }
}
