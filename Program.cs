using System;

namespace PR_10
{
    internal class Program
    {
        static void Main(string [] args)
        {
            Console.Title = "Практическая работа № 10";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");

            const int M = 4, N = 3;
            Random rand = new Random();
            char continueChoice;

            do
            {
                try
                {
                    int[,] matrix = new int[M, N];

                    // Заполнение матрицы случайными числами в диапазоне [-27, 38] включительно
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            matrix[i, j] = rand.Next(-27, 39);
                        }
                    }

                    // Поиск наибольшего нечётного числа
                    int? maxOdd = null;
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            if (matrix[i, j] % 2 != 0)
                            {
                                if (maxOdd == null || matrix[i, j] > maxOdd)
                                    maxOdd = matrix[i, j];
                            }
                        }
                    }

                    // Вывод матрицы с выделением найденного элемента красным цветом
                    Console.WriteLine("\nМатрица:");
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            if (maxOdd.HasValue && matrix[i, j] == maxOdd.Value)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(matrix[i, j].ToString().PadRight(4));
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matrix[i, j].ToString().PadRight(4));
                            }
                        }
                        Console.WriteLine();
                    }

                    if (maxOdd.HasValue)
                        Console.WriteLine($"\nНаибольшее нечётное число: {maxOdd.Value}");
                    else
                        Console.WriteLine("\nНечётных чисел в матрице не найдено.");

                    // Запрос на повторный расчёт
                    Console.Write("\nВыполнить новый расчёт? (Y/N): ");
                    string input = Console.ReadLine()?.Trim().ToUpper();
                    continueChoice = string.IsNullOrEmpty(input) ? 'N' : input;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nЧто-то пошло не так. {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    continueChoice = 'N';
                }
            } while (continueChoice == 'Y');

            Console.WriteLine("\nПрограмма завершена.");
            Console.ReadKey();
        }
    }
}
 