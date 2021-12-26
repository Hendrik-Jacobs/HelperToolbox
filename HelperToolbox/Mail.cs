using System.Text.RegularExpressions;

namespace HelperToolbox;
public static class Mail
{
    private static readonly char[] mailChars = { '-', '.', '@' };

    public static bool IsValidMail(this string mail)
    {
        if (string.IsNullOrEmpty(mail)) { return false; }
        else if (mail.Contains("..")) { return false; }
        else if (mail.Contains("--")) { return false; }
        else if (mail.StartsWith(".")) { return false; }
        else if (mail.StartsWith("-")) { return false; }
        else if (mail.EndsWith(".")) { return false; }
        else if (mail.EndsWith("-")) { return false; }

        foreach (char c in mail)
        {
            if (char.IsLetterOrDigit(c)) { continue; }
            else if (mailChars.Contains(c)) { continue; }
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