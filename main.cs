using System;

class Program
{
    static void Main()
    {
        int N;
        do { Console.WriteLine("Введите количество элементов в массиве (целое число больше нуля):");
        } while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);
        double[] array = new double[N];
        for (int i = 0; i < N; i++)
        {
            double element;
            do { Console.WriteLine($"Введите элемент массива №{i + 1}:");
            } while (!double.TryParse(Console.ReadLine(), out element));

            array[i] = element;
        }
        double sumOddIndex = 0; // вычисление суммы элементов с нечетными номерами
        for (int i = 0; i < N; i += 2) { sumOddIndex += array[i]; }
        int firstNegativeIndex = -1; // нахождение первого и последнего отрицательных элементов
        int lastNegativeIndex = -1;
        for (int i = 0; i < N; i++)
        {
            if (array[i] < 0)
            {
                if (firstNegativeIndex == -1) { firstNegativeIndex = i; }
                lastNegativeIndex = i;
            }
        }

        double sumBetweenNegatives = 0; // вычисление суммы элементов между первым и последним отрицательными элементами
        if (firstNegativeIndex != -1 && lastNegativeIndex != -1) {
            for (int i = firstNegativeIndex + 1; i < lastNegativeIndex; i++) { sumBetweenNegatives += array[i]; }
        }

        for (int i = 0; i < N; i++) { // удаление элементов, модуль которых не превышает единицу
            if (Math.Abs(array[i]) <= 1) { array[i] = 0; }
        }

        Console.WriteLine($"Сумма элементов с нечетными номерами: {sumOddIndex}"); // вывод
        if (firstNegativeIndex != -1 && lastNegativeIndex != -1)
        {
            Console.WriteLine($"Сумма элементов между первым и последним отрицательными элементами: {sumBetweenNegatives}");
        }
        else { Console.WriteLine("Отрицательные элементы не найдены."); }
        Console.WriteLine("Массив после удаления элементов, модуль которых не превышает единицу, и заполнения нулями:");
        foreach (var item in array) { Console.Write($"{item} "); }
    }
}
