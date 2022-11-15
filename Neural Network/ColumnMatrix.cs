using System.Collections;

namespace Neural_Network;

public class ColumnMatrix : Matrix, IEnumerable<double>
{
    public ColumnMatrix(double[,] data) : base(data)
    {
        if (JSize != 1)
            throw new ArgumentException();
    }

    public static ColumnMatrix FromEnumerable(IEnumerable<double> data)
    {
        double[] a = data.ToArray();
        var m = new double[a.Length, 1];
        for (var i = 0; i < a.Length; i++)
        {
            m[i, 0] = a[i];
        }

        return new ColumnMatrix(m);
    }

    public static ColumnMatrix AddOneForBias(ColumnMatrix matrix)
    {
        var m = new double[matrix.ISize, 1];
        m[0, 0] = 1;
        for (var i = 0; i < matrix.ISize; i++)
        {
            m[i + 1, 0] = matrix[i, 0];
        }

        return new ColumnMatrix(m);
    }

    public IEnumerator<double> GetEnumerator()
    {
        for (var i = 0; i < ISize; i++)
            yield return Data[i, 1];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}