namespace Neural_Network;

public class Matrix
{
    protected readonly double[,] Data;
    public readonly int ISize;
    public readonly int JSize;

    public Matrix(double[,] data)
    {
        Data = data;
        ISize = Data.GetLength(0);
        JSize = Data.GetLength(1);
    }

    public static Matrix Random(int iSize, int jSize)
    {
        var generator = new Random();
        var m = new double[iSize, jSize];

        for (var i = 0; i < iSize; i++)
        for (var j = 0; j < jSize; j++)
            m[i, j] = generator.Next(100);
        return new Matrix(m);
    }

    public static Matrix Identity(int size)
    {
        var m = new double[size, size];
        for (var i = 0; i < size; i++)
        {
            m[i, i] = 1;
        }

        return new Matrix(m);
    }

    protected double this[int i, int j]
    {
        get => Data[i, j];
        set => Data[i, j] = value;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        var c = new Matrix(new double[a.ISize, b.JSize]);

        for (var i = 0; i < c.ISize; i++)
        for (var j = 0; j < c.JSize; j++)
        for (var k = 0; k < a.JSize; k++)
            c.Data[i, j] += a.Data[i, k] * b.Data[k, j];

        return c;
    }

    public static ColumnMatrix operator *(Matrix a, ColumnMatrix b)
    {
        var c = new ColumnMatrix(new double[a.ISize, b.JSize]);

        for (var i = 0; i < c.ISize; i++)
        for (var j = 0; j < c.JSize; j++)
        for (var k = 0; k < a.JSize; k++)
            c.Data[i, j] += a.Data[i, k] * b.Data[k, j];

        return c;
    }
}