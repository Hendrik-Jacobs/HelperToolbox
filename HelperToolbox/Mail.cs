using System.Text.RegularExpressions;

namespace HelperToolbox;
public static class Mail
{
    private static char[] mailChars = { '-', '.', '@' };

    public static bool IsValidMail(this string mail)
    {
        if (string.IsNullOrEmpty(mail)) { return false; }
        if (mail.Contains("..")) { return false; }

        foreach (char c in mail)
        {
            if (char.IsLetterOrDigit(c)) { continue; }
            if (mailChars.Contains(c)) { continue; }
            return false;
        }

        try
        {
            return Regex.IsMatch(mail,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}