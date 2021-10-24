using System;

namespace lesson_7
{
    /// <summary>
    /// Класс, хранящий в себе массив и размеры поля
    /// </summary>
    class Field
    {
        public int N { get; set; }
        public int M { get; set; }
        public int[,] FieldArray { get; set; }
        public Field(int n, int m)
        {
            N = n;
            M = m;
            FieldArray = new int[N, M];
        }
    }

/// <summary>
/// Класс для поиска количества маршрутов путем заполнения массива
/// </summary>
    class FindPath
    {
        public Field field { get; set; }
        public int PathAmount { get; set; } // свойство с вычисленным количеством путей
        public FindPath(int n, int m)
        {
            field = new(n, m);
            PathAmount = Find(field.FieldArray);
        }

        public int Find(int[,] fieldArray)
        {
            int i, j;

            for (i = 0; i < field.M; i++)
            {
                fieldArray[0, i] = 1; // заполнить первую строку единицами
            }

            for (i = 1; i < field.N; i++)
            {
                fieldArray[i, 0] = 1; // заполнить первый столбец единицами

                for ( j = 1; j < field.M; j++)
                {
                    fieldArray[i, j] = fieldArray[i, j - 1] + fieldArray[i - 1, j];
                }
            }
            return fieldArray[field.N -1, field.M - 1];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FindPath findPath = new(8, 8);
            Console.WriteLine(findPath.PathAmount);
        }
    }
}
