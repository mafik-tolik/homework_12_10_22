Console.Clear();



// Ex54();
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:          В итоге получается вот такой массив:
// 1 4 7 2                          7 4 2 1
// 5 9 2 3                          9 5 3 2
// 8 4 2 4                          8 4 4 2

void Ex54()
{
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



// Ex56();
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void Ex56()
{
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
    Console.WriteLine($"\nНомер строки с наименьшей суммой: {minIndexSumRow + 1}");
}



Ex58();
// Задача 58: Напишите программу, которая заполнит спирально массив 4 на 4 (числами от 1 до 16.). Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void Ex58()
{

}




