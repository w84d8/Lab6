class MathOperations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int[] Add(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        int[] result = new int[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i] + array2[i];
        }

        return result;
    }

    public static int[,] Add(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || columns != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        int[,] result = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

}
