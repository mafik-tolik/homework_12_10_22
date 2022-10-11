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






