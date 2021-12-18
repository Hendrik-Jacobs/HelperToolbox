using System.Collections.ObjectModel;

namespace HelperToolbox;
public static class Lists
{
    public static IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> input, int start = 0, int interval = 1)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        int i = start - interval;
        foreach (T? t in input)
        {
            yield return (i += interval, t);
        }
    }

    public static IEnumerable<(double, T)> Enumerate<T>(this IEnumerable<T> input, double start = 0, double interval = 1)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        double i = start - interval;
        foreach (T? t in input)
        {
            yield return (i += interval, t);
        }
    }

    public static IEnumerable<(T, F)> Cross<T, F>(this IEnumerable<T> input1, IEnumerable<F> input2)
    {
        if (input1 == null)
        {
            throw new ArgumentNullException(nameof(input1));
        }
        if (input2 == null)
        {
            throw new ArgumentNullException(nameof(input2));
        }

        foreach (T? t in input1)
        {
            foreach (F? t2 in input2)
            {
                yield return (t, t2);
            }
        }
    }

    public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> list, IEnumerable<T> input)
    {
        if (list == null) { list = new(); }
        if (input == null) { return list; }

        foreach (T t in input)
        {
            list.Add(t);
        }

        return list;
    }

    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> input)
    {
        return input ?? Enumerable.Empty<T>();
    }

    public static List<T> Foreach<T>(this IEnumerable<T> source, Func<T, T> action)
    {
        List<T> result = new();
        if (source == null || action == null) { return result; }

        foreach (T item in source)
        {
            T t = action(item);
            result.Add(t);
        }

        return result;
    }

    public static ObservableCollection<T> Foreach<T>(this ObservableCollection<T> source, Func<T, T> action)
    {
        ObservableCollection<T> result = new();
        if (source == null || action == null) { return result; }

        foreach (T item in source)
        {
            T t = action(item);
            result.Add(t);
        }

        return result;
    }
}