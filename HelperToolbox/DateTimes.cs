namespace HelperToolbox;
public static class DateTimes
{
    public static int Seconds(this int milliseconds) => milliseconds * 1000;
    public static int Seconds(this double milliseconds) => (int)milliseconds * 1000;

    public static int Minutes(this int milliseconds) => milliseconds * 60000;
    public static int Minutes(this double milliseconds) => (int)milliseconds * 60000;
}