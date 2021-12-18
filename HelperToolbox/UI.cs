using System.Windows;

namespace HelperToolbox;
public static class UI
{
    public static void MakeVisible(this UIElement element)
    {
        if (element == null) { return; }
        element.Visibility = Visibility.Visible;
    }

    public static void MakeCollapsed(this UIElement element)
    {
        if (element == null) { return; }
        element.Visibility = Visibility.Collapsed;
    }
}