using Newtonsoft.Json;
using System.Reflection;

namespace HelperToolbox;
public static class Other
{
    public static string ToJson<T>(this T instance)
    {
        if (instance == null) { return ""; }
        return JsonConvert.SerializeObject(instance);
    }

    public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
    {
        if (actual == null) { throw new ArgumentNullException(nameof(actual)); }
        if (lower == null) { throw new ArgumentNullException(nameof(lower)); }
        if (upper == null) { throw new ArgumentNullException(nameof(upper)); }

        return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
    }

    public static T With<T>(this T obj, Action<T> act)
    {
        if (obj == null) { throw new ArgumentNullException(nameof(obj)); }
        if (act == null) { throw new ArgumentNullException(nameof(act)); }

        act(obj);
        return obj;
    }

    public static bool PropertiesEqauls<T>(this T item1, T item2)
    {
        if (item1 == null)
        {
            throw new ArgumentNullException(nameof(item1));
        }
        if (item2 == null)
        {
            throw new ArgumentNullException(nameof(item2));
        }

        PropertyInfo[] propertyInfos;
        propertyInfos = typeof(T).GetProperties();

        foreach (PropertyInfo info in propertyInfos)
        {
            object? o = item1.GetType()?
                             .GetProperty(info.Name)?
                             .GetValue(item1);

            object? p = item2.GetType()?
                             .GetProperty(info.Name)?
                             .GetValue(item2);

            if (o == null && p == null) { continue; }
            else if (o == null) { return false; }
            else if (p == null) { return false; }
            else if (!o.Equals(p)) { return false; }
        }

        return true;
    }

    public static T DeepCopy<T>(this T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        string json = item.ToJson();
        return JsonConvert.DeserializeObject<T>(json);
    }
}