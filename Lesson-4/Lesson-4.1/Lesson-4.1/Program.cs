using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_4._1
{
    /// <summary>
    /// Класс, хранящий и заполняющий массив с рандомными строками
    /// </summary>
    class RandomStringArray
    {
        public int MyArraySize { get; set; }

        public RandomStringArray(int arraySize)
        {
            MyArraySize = arraySize;
        }

        /// <summary>
        /// Заполнение массива уникальными рандомными строками
        /// </summary>
        /// <returns>Массив указанного размера, заполненный уникальными случайными строками</returns>
        public string[] FillArray()
        {
            string[] coreArray = new string[MyArraySize];

            for (int i = 0; i < coreArray.Length; i++)
            {
                coreArray[i] = Guid.NewGuid().ToString();
            }

            return coreArray;
        }
    }

    /// <summary>
    /// Класс, содержащий сущности для поиска искомого значения в массиве
    /// </summary>
    class ArraySearch
    {

        public ArraySearch(string[] coreArray, string requiredString)
        {

            Search(coreArray, requiredString);
        }

        /// <summary>
        /// Поиск строки в массиве
        /// </summary>
        /// <param name="coreArray">исходный массив</param>
        /// <param name="requiredString">искомая строка</param>
        private void Search(string[] coreArray, string requiredString)
        {
            Stopwatch sw = new();

            sw.Start();
            for (int i = 0; i < coreArray.Length; i++)
            {
                if (coreArray[i] == requiredString)
                {
                    Console.WriteLine("Искомая строка найдена в массиве!");
                    break;
                }
            }
            sw.Stop();
            Console.WriteLine($"Время поиска в массиве: {sw.ElapsedMilliseconds}мс\t");
        }
    }

    /// <summary>
    /// Класс, содержащий сущности для поиска искомой строки в HashSet-коллекции
    /// </summary>
    class HashSetSearch
    {
        public HashSet<string> MyHashSetList { get; set; }
        public string RequiredString { get; set; }

        public HashSetSearch(string[] coreArray, string requiredString)
        {
            RequiredString = requiredString;
            FillHashSet(coreArray);
            Search();
        }

        /// <summary>
        /// Заполнение коллекции на основе исходного массива
        /// </summary>
        /// <param name="coreArray">исходный массив</param>
        private void FillHashSet(string[] coreArray)
        {
            MyHashSetList = new HashSet<string>();

            for (int i = 0; i < coreArray.Length; i++)
            {
                MyHashSetList.Add(coreArray[i]);
            }
        }

        /// <summary>
        /// Поиск наличия искомой строки в HashSet-коллекции
        /// </summary>
        private void Search()
        {
            Stopwatch sw = new();

            sw.Start();
            if (MyHashSetList.Contains(RequiredString))
            {
                Console.WriteLine();
                Console.WriteLine("Искомая строка найдена в HashSet!");
            }
            sw.Stop();
            Console.WriteLine($"Время поиска в HashSet: {sw.ElapsedMilliseconds}мс"); // почему всегда 0?
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = 10_000_000;
            Random random = new();

            RandomStringArray randomArr = new(number);

            string[] coreArray = randomArr.FillArray();
            string requiredString = coreArray[random.Next(0, number - 1)];

            ArraySearch arSearch = new(coreArray, requiredString);

            HashSetSearch hsSearch = new(coreArray, requiredString);
        }
    }
}
