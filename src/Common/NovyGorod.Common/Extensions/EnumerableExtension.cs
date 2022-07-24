namespace NovyGorod.Common.Extensions;

public static class EnumerableExtension
{
    public static async Task ForEachOneByOneAsync<T>(this IEnumerable<T> items, Func<T, Task> func)
    {
        items = items ?? throw new ArgumentNullException(nameof(items));
        func = func ?? throw new ArgumentNullException(nameof(func));

        foreach (var item in items)
        {
            await func(item);
        }
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
    {
        return items?.Any() != true;
    }
}