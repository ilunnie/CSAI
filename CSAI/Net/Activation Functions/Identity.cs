using System;

namespace CSAI.Net.ActivationFunctions;

public static partial class ActivationFunctions
{
    [ActivationFunction("Identity")]
    public static double Identity(double x) => x;
}