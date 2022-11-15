namespace Neural_Network;

public class Network
{
    private readonly Layer[] _layers;

    public Network(int numberOfLayers)
    {
        _layers = new Layer[numberOfLayers];

        var generator = new Random();
        int layerSize = generator.Next(10);
        for (var i = 0; i < numberOfLayers; i++)
        {
            int nextLayerSize = generator.Next(10);
            var weights = Matrix.Random(layerSize, nextLayerSize);
            _layers[i] = new Layer(layerSize, nextLayerSize, weights);
            layerSize = nextLayerSize;
        }
    }

    public Network(int numberOfLayers, int[] layersSizes)
    {
        if (layersSizes.Length != numberOfLayers + 1)
            throw new ArgumentException();

        _layers = new Layer[numberOfLayers];

        for (var i = 0; i < numberOfLayers; i++)
        {
            int layerSize = layersSizes[i];
            int nextLayerSize = layersSizes[i + 1];
            var weights = Matrix.Random(layerSize, nextLayerSize);
            _layers[i] = new Layer(layerSize, nextLayerSize, weights);
        }
    }

    public ColumnMatrix Run(ColumnMatrix inputs) =>
        _layers.Aggregate(inputs, (current, layer) => layer.Run(current));
}