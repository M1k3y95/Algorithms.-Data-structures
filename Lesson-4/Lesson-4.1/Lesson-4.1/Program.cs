using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_4._1
{
    class ArraySearch
    {
        private string[] MyArray { get; set; }

        public ArraySearch(int arraySize)
        {
            MyArray = new string[arraySize];
            Search(MyArray);
        }

        private string[] FillArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Guid.NewGuid().ToString();
            }
            return array;
        }

        private string Search(string[] array)
        {
            Stopwatch sw = new();
            FillArray(array);
            string searchValue = array[array.Length - 100];

            sw.Start();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchValue)
                {
                    Console.WriteLine("Строка найдена");
                    sw.Stop();
                    Console.WriteLine($"Время поиска в массиве {sw.ElapsedMilliseconds}мс");
                    return array[i];
                }
            }
            sw.Stop();
            Console.WriteLine("Искомой строки не существует!");
            Console.WriteLine($"Время поиска в массиве {sw.ElapsedMilliseconds}мс");
            return null;
        }
    }

    class HashSetSearch
    {

        public HashSetSearch(int size)
        {
            Search(size);
        }

        private HashSet<string> FillHashSet(HashSet<string> someList, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i == size - 5)
                {
                    someList.Add("Найди меня");
                    continue;
                }
                someList.Add(Guid.NewGuid().ToString());
            }
            return someList;
        }

        private void Search(int size)
        {
            Stopwatch sw = new();
            HashSet<string> someList = new();
            someList = FillHashSet(someList, size);

            sw.Start();
            if (someList.Contains("Найди меня"))
            {
                Console.WriteLine("Строка найдена");
                sw.Stop();
                Console.WriteLine($"Время поиска в HashSet {sw.ElapsedMilliseconds}мс");
            }
            else
            {
                Console.WriteLine("Строка не найдена");
                sw.Stop();
                Console.WriteLine($"Время поиска в HashSet {sw.ElapsedMilliseconds}мс");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = 10_000_000;

            ArraySearch arraySearch = new ArraySearch(number);

            Console.WriteLine();

            HashSetSearch hashSetSearch = new HashSetSearch(number);
        }
    }
}
