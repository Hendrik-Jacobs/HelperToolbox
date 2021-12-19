using System.Data;
using System.Reflection;

namespace HelperToolbox;
public static class DataTables
{
    public static DataTable CreateDataTable(this IEnumerable<string> columns, string name = "")
    {
        if (name == null)
        {
            name = "";
        }

        if (columns == null)
        {
            columns = new List<string>();
        }

        DataTable result = new(name);

        foreach (string column in columns)
        {
            result.Columns.Add(column);
        }

        return result;
    }

    public static DataTable ToDataTable<T>(this IEnumerable<T> items, string name = "")
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        PropertyInfo[] propertyInfos;
        propertyInfos = typeof(T).GetProperties();

        if (propertyInfos.Length == 0)
        {
            return new(name);
        }

        string[] columns = propertyInfos.Select(x => x.Name).ToArray();
        DataTable table = columns.CreateDataTable(name);

        foreach (T t in items)
        {
            DataRow row = table.NewRow();
            foreach (PropertyInfo info in propertyInfos)
            {
                object? o = t?.GetType()?
                              .GetProperty(info.Name)?
                              .GetValue(t);

                row[info.Name] = o;
            }

            table.Rows.Add(row);
        }

        return table;
    }
}