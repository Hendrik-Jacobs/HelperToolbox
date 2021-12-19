using System.Data;
using System.Reflection;

namespace HelperToolbox;
public static class DataTables
{
    public static DataTable CreateDataTable(IEnumerable<string> columns)
    {
        if (columns == null) { return new(); }
        return CreateDataTable("" , columns);
    }
    public static DataTable CreateDataTable(string name, IEnumerable<string> columns)
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

    public static DataTable ToDataTable<T>(this IEnumerable<T> item, string name = "")
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        PropertyInfo[] propertyInfos;
        propertyInfos = typeof(T).GetProperties();

        if (propertyInfos.Length == 0)
        {
            return new(name);
        }

        string[] columns = propertyInfos.Select(x => x.Name).ToArray();
        DataTable table = CreateDataTable(name, columns);

        foreach (T t in item)
        {
            DataRow row = table.NewRow();
            foreach (PropertyInfo info in propertyInfos)
            {
                object? o = t.GetType()?
                             .GetProperty(info.Name)?
                             .GetValue(t);

                row[info.Name] = o;
            }

            table.Rows.Add(row);
        }

        return table;
    }
}