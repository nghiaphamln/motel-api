using System.Data;
using System.Reflection;

namespace TDMUMotelWeb.Helper;

public static class ObjectExtensions
{
    public static List<T>? ToList<T>(this DataTable? table) where T : new()
    {
        if (table == null)
        {
            return null;
        }

        var list = typeof(T).GetProperties().ToList();
        var list2 = new List<PropertyInfo>();
        var list4 = (from DataColumn column in table.Columns select column.ColumnName.ToUpper()).ToList();

        var index = 0;
        for (; index < list.Count; index++)
        {
            var item2 = list[index];
            if (list4.Contains(item2.Name.ToUpper()))
            {
                list2.Add(item2);
            }
        }

        return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, list2)).ToList();
    }
    
    private static T CreateItemFromRow<T>(DataRow row, IEnumerable<PropertyInfo> properties) where T : new()
    {
        T val = new();
        try
        {
            foreach (var property in properties)
            {
                if (row[property.Name] == DBNull.Value) continue;
                try
                {
                    property.SetValue(val, Convert.ChangeType(row[property.Name], property.PropertyType), null);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return val;
    }
}