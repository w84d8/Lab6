class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

        return new Quaternion(w, x, y, z);
    }

    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    public Quaternion Inverse()
    {
        double normSquared = W * W + X * X + Y * Y + Z * Z;
        if (normSquared == 0)
            throw new InvalidOperationException("Quaternion has zero norm, cannot compute inverse.");

        double inverseFactor = 1.0 / normSquared;
        return new Quaternion(W * inverseFactor, -X * inverseFactor, -Y * inverseFactor, -Z * inverseFactor);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    public double[,] ToRotationMatrix()
    {
        double[,] matrix = new double[3, 3];

        double xx = X * X;
        double xy = X * Y;
        double xz = X * Z;
        double xw = X * W;
        double yy = Y * Y;
        double yz = Y * Z;
        double yw = Y * W;
        double zz = Z * Z;
        double zw = Z * W;

        matrix[0, 0] = 1 - 2 * (yy + zz);
        matrix[0, 1] = 2 * (xy - zw);
        matrix[0, 2] = 2 * (xz + yw);
        matrix[1, 0] = 2 * (xy + zw);
        matrix[1, 1] = 1 - 2 * (xx + zz);
        matrix[1, 2] = 2 * (yz - xw);
        matrix[2, 0] = 2 * (xz - yw);
        matrix[2, 1] = 2 * (yz + xw);
        matrix[2, 2] = 1 - 2 * (xx + yy);

        return matrix;
    }

    public static Quaternion FromRotationMatrix(double[,] matrix)
    {
        if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            throw new ArgumentException("Rotation matrix must be 3x3.");

        double trace = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
        double w, x, y, z;

        if (trace > 0)
        {
            double s = 0.5 / Math.Sqrt(trace + 1.0);
            w = 0.25 / s;
            x = (matrix[2, 1] - matrix[1, 2]) * s;
            y = (matrix[0, 2] - matrix[2, 0]) * s;
            z = (matrix[1, 0] - matrix[0, 1]) * s;
        }
        else if (matrix[0, 0] > matrix[1, 1] && matrix[0, 0] > matrix[2, 2])
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[0, 0] - matrix[1, 1] - matrix[2, 2]);
            w = (matrix[2, 1] - matrix[1, 2]) / s;
            x = 0.25 * s;
            y = (matrix[0, 1] + matrix[1, 0]) / s;
            z = (matrix[0, 2] + matrix[2, 0]) / s;
        }
        else if (matrix[1, 1] > matrix[2, 2])
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[1, 1] - matrix[0, 0] - matrix[2, 2]);
            w = (matrix[0, 2] - matrix[2, 0]) / s;
            x = (matrix[0, 1] + matrix[1, 0]) / s;
            y = 0.25 * s;
            z = (matrix[1, 2] + matrix[2, 1]) / s;
        }
        else
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[2, 2] - matrix[0, 0] - matrix[1, 1]);
            w = (matrix[1, 0] - matrix[0, 1]) / s;
            x = (matrix[0, 2] + matrix[2, 0]) / s;
            y = (matrix[1, 2] + matrix[2, 1]) / s;
            z = 0.25 * s;
        }

        return new Quaternion(w, x, y, z);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
