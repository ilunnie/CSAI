using System;

namespace CSAI.Net;

public class Perceptron : IFunnel<double>
{
    private double[] _input;
    public double[] Input { get => _input; set => _input = value; }
    public double[] Weights { get; set; }
    public double Bias { get; set; }
    public Func<double, double> Activation { get; private set; }

    public Perceptron(Func<double, double> activation)
    {
        this.Activation = activation;
    }

    public double[] Output()
    {
        double sum = 0;
        for (int i = 0; i < _input.Length; i++)
            sum += _input[i] * Weights[i];
        sum += Bias;

        return new double[]{Activation(sum)};
    }
}
