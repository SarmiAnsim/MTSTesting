/// Реализуйте метод по следующей сигнатуре:

/// <summary>
/// <para> Отсчитать несколько элементов с конца </para>
/// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
/// </summary> 
/// <typeparam name="T"></typeparam>
/// <param name="enumerable"></param>
/// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
/// <returns></returns>

/// Возможно ли реализовать такой метод выполняя перебор значений перечисления только 1 раз?


class Program
{
    public static void Main()
    {
        var result = Solution.EnumerateFromTail(new[] {1,2,3,4}, null);
            Console.WriteLine(String.Join(' ', result));
    }
}

static class Solution
{
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            tailLength = tailLength ?? 0;
            int startIndex = 0;
            if (tailLength != 0)      // При tailLength = 0 или tailLength = null перебор значений только 1 раз
                startIndex = tailLength.Value - enumerable.Count();

            var item = enumerable.GetEnumerator();
            while(item.MoveNext())
            {
                if (tailLength.Value != 0)
                    yield return (item.Current, startIndex >= 0 ? tailLength.Value - startIndex - 1 : null);
                else
                    yield return (item.Current, null);
                ++startIndex;
            }
    }
}
