class Program
{
    static void Main()
    {

        int sum = MathOperations.Add(5, 10);
        Console.WriteLine($"Sum of numbers: {sum}");

        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };
        int[] arraySum = MathOperations.Add(array1, array2);
        Console.WriteLine("Sum of arrays:");
        Console.WriteLine(string.Join(", ", arraySum));

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int[,] matrixSum = MathOperations.Add(matrix1, matrix2);
        Console.WriteLine("Sum of matrices:");
        for (int i = 0; i < matrixSum.GetLength(0); i++)
        {
            for (int j = 0; j < matrixSum.GetLength(1); j++)
            {
                Console.Write($"{matrixSum[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}