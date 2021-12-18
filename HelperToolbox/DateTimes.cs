namespace HelperToolbox;
public static class DateTimes
{
    public static int Seconds(this int milliseconds) => milliseconds * 1000;
    public static int Minutes(this int milliseconds) => milliseconds * 60000;
}