using System;

namespace CSAI.Net.Initializers;

public static partial class Initializers
{
    [Initializer("RandomNormal", "NormalRandom", "random_normal", "normal_random")]
    public static double RandomNormal(double mean = 0, double standard_deviation = 1)
    {
        double U = Random.NextDouble();
        return mean + standard_deviation * Math.Sqrt(-2 * Math.Log(U)) * Math.Cos(2 * Math.PI * U);
    }
}