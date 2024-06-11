using System;

namespace CSAI.Net.ActivationFunctions;

public class InvalidActionFunctionName : Exception
{
    public InvalidActionFunctionName(string message) : base(message) {}
}