namespace Neural_Network;

public class Neuron
{
    private readonly ActivationFunction _function;

    public Neuron()
    {
        _function = input => input > 0 ? 1: 0;
    }

    public double Run(double input) => _function(input);
}