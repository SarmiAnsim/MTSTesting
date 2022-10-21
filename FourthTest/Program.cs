/// 4.	Высший сорт.
/// Реализуйте метод Sort. Известно, что потребители метода зачастую не будут вычитывать данные до конца. 
/// Оптимально ли Ваше решение с точки зрения скорости выполнения? С точки зрения потребляемой памяти?

/// <summary>
/// Возвращает отсортированный по возрастанию поток чисел
/// </summary>
/// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
/// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
/// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
/// <returns>Отсортированный по возрастанию поток чисел.</returns>

public class Program
{
    public static void Main()
    {
        var result = Sort(new[] { 3, 0, 5, 3, 1, 8, 7, 7, 5 }, 3, 8);
        Console.Write(String.Join(' ', result));
    }
    public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)  // Память - O(n) в худшем случае, Время - O(n^2) в худшем случае
    {
        var values = new int[maxValue + 1];
        int bottomBorder = 0;
        
        foreach (int x in inputStream)
        {
            ++values[x];
        
            int upperBorder = x - sortFactor;
            while (bottomBorder < upperBorder)
            {
                while (values[bottomBorder]-- > 0)
                    yield return bottomBorder;
                ++bottomBorder;
            }
        }
        Console.Write('!');
        while (bottomBorder < values.Length)
        {
            while (values[bottomBorder]-- > 0)
                yield return bottomBorder;
            ++bottomBorder;
        }
    }

}
