namespace Neural_Network;

public class Layer
{
    private readonly Neuron[] _neurons;
    private readonly Matrix _weights;
    private readonly int _size;

    public Layer(int size, int nextLayerSize, Matrix weights)
    {
        if (weights.ISize != size + 1 || weights.JSize != nextLayerSize)
            throw new ArgumentException();

        _weights = weights;
        _size = size;
        _neurons = new Neuron[_size];
    }

    public ColumnMatrix Run(ColumnMatrix inputs)
    {
        if (inputs.ISize != _size)
            throw new ArgumentException();

        var activatedInput = ColumnMatrix.FromEnumerable(
            inputs.Zip(_neurons, (input, neuron) => neuron.Run(input)));
        activatedInput = ColumnMatrix.AddOneForBias(activatedInput);
        return _weights * activatedInput;
    }
}