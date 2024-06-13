using System;

namespace CSAI.Net.ActivationFunctions;

public class InvalidActionFunction : Exception
{
    public InvalidActionFunction(string message) : base(message) {}
}