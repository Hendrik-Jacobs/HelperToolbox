using System.Data;

namespace HelperToolbox;
public static class DataTables
{
    public static DataTable CreateDataTable(IEnumerable<string> columns)
    {
        if (columns == null) { return new("Table"); }
        return CreateDataTable("Table", columns);
    }
    public static DataTable CreateDataTable(string name, IEnumerable<string> columns)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = "Table";
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
}