using System;

namespace CSAI.Net.ActivationFunctions;

public static partial class ActivationFunctions
{
    [ActivationFunction("Identity")]
    public static double Identity(double x) => x;

    [ActivationFunction("test")]
    public static double test(double x, double a) => x + a;
}