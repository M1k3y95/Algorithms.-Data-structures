using System;

namespace Lesson_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;

            TestCase();

            Console.WriteLine("Вычисляем число Фибоначчи. Введите n");

            if (!long.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Некорректный ввод!");
                return;
            }
                Console.WriteLine($"Результат: {FindFibonacchi(n)}");
        }

        private static long FindFibonacchi(long n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n <= 2 && n >= 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                n = -n;
                return -FindFibonacchi(n - 2) + -FindFibonacchi(n - 1);
            }

            return FindFibonacchi(n - 2) + FindFibonacchi(n - 1);
        }

        private static void TestCase()
        {
            Console.WriteLine($"0   |   {FindFibonacchi(0)}");
            Console.WriteLine($"7   |   {FindFibonacchi(7)}");
            Console.WriteLine($"10  |   {FindFibonacchi(10)}");
            Console.WriteLine($"-10 |   {FindFibonacchi(-10)}");
            Console.WriteLine($"20  |   {FindFibonacchi(20)}\n");
        }
    }
}
