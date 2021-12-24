namespace HelperToolbox;
public static class Numbers
{
    public static bool IsInt(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return int.TryParse(value, out _);
    }

    public static bool IsPositivInt(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return int.TryParse(value, out _) && !value.Contains('-');
    }

    public static bool IsNegativInt(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return int.TryParse(value, out _) && value.Contains('-');
    }

    public static bool IsDouble(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return double.TryParse(value, out _);
    }

    public static bool IsPositivDouble(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return double.TryParse(value, out _) && !value.Contains('-');
    }

    public static bool IsNegativDouble(this string value, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }
        return double.TryParse(value, out _) && value.Contains('-');
    }

    public static int ToInt(this string value, int defaultValue = 0)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }

        if (int.TryParse(value, out int result))
        {
            return result;
        }
        return defaultValue;
    }

    public static double ToDouble(this string value, double defaultValue = 0)
    {
        if (string.IsNullOrEmpty(value)) { return defaultValue; }

        if (double.TryParse(value, out double result))
        {
            return result;
        }
        return defaultValue;
    }

    public static bool ToBool(this int value)
    {
        return value > 0;
    }

    public static int ToInt(this bool value)
    {
        return value ? 1 : 0;
    }
}