using System;
using System.Diagnostics;

namespace Lesson_3._1
{
    class PointClass
    {
        public double DoublePointA { get; set; }
        public double DoublePointB { get; set; }

        public double GetDistance(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }

    struct PointStruct
    {
        public double DoublePointA { get; set; }
        public double DoublePointB { get; set; }

        public double GetDistance(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                CalculateDistanceForClass();
            }

            sw.Stop();

            Console.WriteLine($"Время выполнения для класса: {sw.ElapsedMilliseconds}мс");

            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                CalculateDistanceForStruct();
            }

            sw.Stop();

            Console.WriteLine($"Время выполнения для структуры: {sw.ElapsedMilliseconds}мс");
        }

        /// <summary>
        /// Вычисление дистанции между точками для класса
        /// </summary>
        static void CalculateDistanceForClass()
        {
            int[] numbers = new int[4];
            GetArray(numbers);

            PointClass distance = new PointClass()
            {
                DoublePointA = numbers[0] - numbers[1],
                DoublePointB = numbers[2] - numbers[3]
            };

            distance.GetDistance(distance.DoublePointA, distance.DoublePointB);
        }

        /// <summary>
        /// Вычисление дистанции между точками для структуры
        /// </summary>
        static void CalculateDistanceForStruct()
        {
            int[] numbers = new int[4];
            GetArray(numbers);

            PointStruct distance = new PointStruct()
            {
                DoublePointA = numbers[0] - numbers[1],
                DoublePointB = numbers[2] - numbers[3]
            };

            distance.GetDistance(distance.DoublePointA, distance.DoublePointB);
        }

        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] GetArray(int[] arr)
        {
            Random randomizer = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randomizer.Next(1, 100);
            }

            return arr;
        }
    }
}
