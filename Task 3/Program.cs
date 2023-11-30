class Program
{
    static void Main()
    {

        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        Quaternion sum = q1 + q2;
        Console.WriteLine($"Sum: {sum.W}, {sum.X}, {sum.Y}, {sum.Z}");

        Quaternion difference = q1 - q2;
        Console.WriteLine($"Difference: {difference.W}, {difference.X}, {difference.Y}, {difference.Z}");

        Quaternion product = q1 * q2;
        Console.WriteLine($"Product: {product.W}, {product.X}, {product.Y}, {product.Z}");

        double norm = q1.Norm();
        Console.WriteLine($"Norm: {norm}");

        Quaternion conjugate = q1.Conjugate();
        Console.WriteLine($"Conjugate: {conjugate.W}, {conjugate.X}, {conjugate.Y}, {conjugate.Z}");

        Quaternion inverse = q1.Inverse();
        Console.WriteLine($"Inverse: {inverse.W}, {inverse.X}, {inverse.Y}, {inverse.Z}");

        Console.WriteLine($"Equality: {q1 == q2}");

        double[,] rotationMatrix = q1.ToRotationMatrix();
        Console.WriteLine("Rotation Matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{rotationMatrix[i, j]} ");
            }
            Console.WriteLine();
        }

        double[,] testMatrix = { { -0.5, 0.5, -0.707 }, { -0.5, 0.5, 0.707 }, { 0.707, 0.707, 0 } };
        Quaternion fromMatrix = Quaternion.FromRotationMatrix(testMatrix);
        Console.WriteLine($"Quaternion from Matrix: {fromMatrix.W}, {fromMatrix.X}, {fromMatrix.Y}, {fromMatrix.Z}");
    }
}