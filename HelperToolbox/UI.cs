using System.Windows;
using System.Windows.Controls;

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

    public static Grid GetGrid(int rows, int columns, string name = "")
    {
        Grid grid = new();

        if (string.IsNullOrEmpty(name) == false)
        {
            if (name.AllLettersDigitsOrUnderScores() == false)
            {
                throw new ArgumentException(null, nameof(name));
            }

            grid.Name = name;
        }

        for (int r = 0; r < rows; r++)
        {
            RowDefinition row = new();
            row.Height = new GridLength(1, GridUnitType.Auto);
            grid.RowDefinitions.Add(row);
        }

        for (int c = 0; c < columns; c++)
        {
            ColumnDefinition column = new();
            column.Width = new GridLength(1, GridUnitType.Auto);
            grid.ColumnDefinitions.Add(column);
        }

        return grid;
    }

    
}