using System.Data;
using System.Text;

namespace HelperToolbox;
public static class Strings
{
    public static bool IsAllLetters(this string value, bool defauLt = false)
    {
        if (string.IsNullOrEmpty(value)) { return defauLt; }
        return value.Any(c => !char.IsLetter(c));
    }

    public static string ToTitleCase(this string text)
    {
        if (text == null) return "";

        System.Globalization.CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

        return textInfo.ToTitleCase(text.ToLower());
    }

    public static string[] Remove(this string[] input, int index)
    {
        if (input == null) { return Array.Empty<string>(); }
        if (index < 0) { return input; }
        if (index >= input.Length) { return input; }

        string[] a = input[..index];
        index++;
        string[] b = input[index..];

        return a.Concat(b).ToArray();
    }

    public static string ToCsv(this DataRow input, string seperator = ",")
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        List<string> list = new();

        foreach (object? item in input.ItemArray)
        {
            if (item == null) { continue; }
            string s = item.ToString();
            list.Add(s);
        }

        return list.ToCsv(seperator);
    }

    public static string ToCsv(this DataTable input, string seperator = ",")
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        StringBuilder sb = new();

        foreach(DataRow row in input.Rows)
        {
            sb.AppendLine(row.ToCsv(seperator));
        }

        return sb.ToString();
    }

    public static string ToCsv<T>(this IEnumerable<T> input, string seperator = ",")
    {
        if (seperator == null)
        {
            seperator = ",";
        }

        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        StringBuilder sb = new();

        foreach (T item in input)
        {
            if (item == null) { continue; }
            sb.Append(item.ToString());
            sb.Append(seperator);
        }

        string result = sb.ToString();
        if (result.Length > 2 && seperator.Length > 0)
        {
            result = result[..^seperator.Length];
        }

        return result;
    }

    public static string SplitAndGetLast(string input, char splitter)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        if (splitter == null)
        {
            throw new ArgumentNullException(nameof(splitter));
        }

        int index = input.LastIndexOf(splitter) + 1;

        if (index == 0) { return input; }
        if (index == input.Length) { return ""; }
        return input[index..];
    }
}