using System;

namespace Lesson_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            TestCase();

            while (true)
            {
                Console.WriteLine("Простое или нет? Введите число для проверки");
                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Неккоректный ввод. Попробуйте еще раз\n");
                    continue;
                }
                Console.WriteLine(PrimeNumberTest(number) + "\n");
            }
        }

        static string PrimeNumberTest(int number)
        {
            int d = 0;

            if (number < 0)
            {
                number = -number;
            }

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    d++;
                }
            }

            if (d == 0)
            {
                return "Простое";
            }
            else
            {
                return "Не простое";
            }
        }

        static void TestCase()
        {
            string case1 = PrimeNumberTest(13);

            string case2 = PrimeNumberTest(15);

            string case3 = PrimeNumberTest(7);

            string case4 = PrimeNumberTest(-13);

            string case5 = PrimeNumberTest(-15);

            Console.WriteLine($"13: {case1}   |   15: {case2}    |   7: {case3}   |   -13: {case4}    |   -15: {case5}\n");
        }
    }
}
