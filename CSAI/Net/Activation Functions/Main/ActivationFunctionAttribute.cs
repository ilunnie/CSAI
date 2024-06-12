using System;

namespace CSAI.Net.ActivationFunctions;

[AttributeUsage(AttributeTargets.Method)]
public class ActivationFunctionAttribute : Attribute
{
    public string FunctionName { get; }

    public ActivationFunctionAttribute(string functionName)
        => FunctionName = functionName;
}