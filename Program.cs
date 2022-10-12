Console.Clear();



Ex54();
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:          В итоге получается вот такой массив:
// 1 4 7 2                          7 4 2 1
// 5 9 2 3                          9 5 3 2
// 8 4 2 4                          8 4 4 2

void Ex54()
{
    Console.WriteLine("Задача 54:\n");
    Random random = new Random();

    int rows = random.Next(5, 8);
    int columns = random.Next(5, 8);
    Console.WriteLine($"Размер массива: {rows} * {columns}");

    int[,] numbers = new int[rows, columns];

    LibraryHelp.Methods.FillArray(numbers, 0, 9);
    LibraryHelp.Methods.PrintArray(numbers);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 1; j < columns; j++)
        {
            for (int k = 0; k < columns - j; k++)
            {
                if (numbers[i, k] < numbers[i, k + 1])
                {
                    (numbers[i, k], numbers[i, k + 1]) = (numbers[i, k + 1], numbers[i, k]);
                }
            }
        }
    }

    LibraryHelp.Methods.PrintArray(numbers);
}



Ex56();
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void Ex56()
{
    Console.WriteLine("Задача 56:\n");
    Random random = new Random();

    int rows = random.Next(5, 8);
    int columns = random.Next(5, 8);
    Console.WriteLine($"Размер массива: {rows} * {columns}");

    int[,] numbers = new int[rows, columns];

    LibraryHelp.Methods.FillArray(numbers, 0, 9);
    LibraryHelp.Methods.PrintArray(numbers);

    int minSumRow = 999999999;
    int minIndexSumRow = 0;

    for (int i = 0; i < rows; i++)
    {
        int sumColumns = 0;

        for (int j = 0; j < columns; j++)
        {
            sumColumns += numbers[i, j];
        }
        Console.WriteLine($"Сумма {i + 1}-й строки: {sumColumns}");

        if (sumColumns < minSumRow)
        {
            minSumRow = sumColumns;
            minIndexSumRow = i;
        }
    }
    Console.WriteLine($"\nНомер строки с наименьшей суммой: {minIndexSumRow + 1}\n");
}



Ex58(); // подходит для заполнения массива по спирали с разным количеством строк и столбцов (не только для 4 на 4).
// Задача 58: Напишите программу, которая заполнит спирально массив 4 на 4 (числами от 1 до 16.). Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void Ex58()
{
    Console.WriteLine("Задача 58:\n");
    Random random = new Random();

    int rows = 6;
    int columns = 9;

    Console.WriteLine($"Размер массива: {rows} * {columns}");

    int[,] numbers = new int[rows, columns];

    int turningPoint = 0; // переменную будем использовать для точки поворота.

    int count = 1; // этим значением будем одновременно заполнять массив и использовать его как счетчик (пока значение не достигнет <rows * columns> включительно).
    int i = 0;
    int j = 0;

    while (count <= rows * columns)
    {
        numbers[i, j] = count;

        if (i == turningPoint && j < columns - turningPoint - 1) j++;
        else if (j == columns - turningPoint - 1 && i < rows - turningPoint - 1) i++;
        else if (i == rows - turningPoint - 1 && j > turningPoint) j--;
        else i--;

        if (i == turningPoint + 1 && j == turningPoint && turningPoint != columns - turningPoint - 1) turningPoint++;
        // Проверка на <turningPoint != columns - turningPoint - 1> нужна в самом конце, чтобы заполнение после предпоследнего шага не пошло в обратную сторону. 
        // Эта проверка актуальна, когда <rows > columns> на <+2> (например, 7*5, 9*7). Возможно есть и другие размеры массива, где понадобится эта проверка. 

        count++;
    }
    LibraryHelp.Methods.PrintArray(numbers);
}



Ex61(); // программа одновремренно учитывает произведение матрицы 1 на матрицу 2, и наоборот - матрицы 2 на матрицу 1. 
// Задача 61: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

void Ex61()
{
    Console.WriteLine("Задача 61:\n");
    Random random = new Random();

    int rows1 = random.Next(3, 6);
    int columns1 = random.Next(3, 6);
    Console.WriteLine($"Размер матрицы numbers1: {rows1} * {columns1}");
    int[,] numbers1 = new int[rows1, columns1];
    LibraryHelp.Methods.FillArray(numbers1, 0, 9);
    LibraryHelp.Methods.PrintArray(numbers1);

    int rows2 = random.Next(3, 6);
    int columns2 = random.Next(3, 6);
    Console.WriteLine($"Размер матрицы numbers2: {rows2} * {columns2}");
    int[,] numbers2 = new int[rows2, columns2];
    LibraryHelp.Methods.FillArray(numbers2, 0, 9);
    LibraryHelp.Methods.PrintArray(numbers2);

    int rows = 0;
    int columns = 0;
    int count = 0; // счетчик для будущего сложения "произведений матриц". 

    if (columns1 != rows2 && columns2 != rows1) Console.WriteLine($"Невозможно найти произведение матриц");

    if (columns1 == rows2)
    {
        rows = rows1;
        columns = columns2;
        count = rows2;

        int[,] multiplicationMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int sumMultiplications = 0;

                for (int k = 0; k < count; k++)
                {
                    sumMultiplications += numbers1[i, k] * numbers2[k, j];
                }
                multiplicationMatrix[i, j] = sumMultiplications;
            }
        }
        Console.WriteLine("Произведение матрицы numbers1 на матрицу numbers2:");
        LibraryHelp.Methods.PrintArray(multiplicationMatrix);
    }

    if (columns2 == rows1)
    {
        rows = rows2;
        columns = columns1;
        count = rows1;

        int[,] multiplicationMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int sumMultiplications = 0;
                for (int k = 0; k < count; k++)
                {
                    sumMultiplications += numbers2[i, k] * numbers1[k, j]; ;
                }
                multiplicationMatrix[i, j] = sumMultiplications;
            }
        }
        Console.WriteLine("Произведение матрицы numbers2 на матрицу numbers1:");
        LibraryHelp.Methods.PrintArray(multiplicationMatrix);
    }
}
