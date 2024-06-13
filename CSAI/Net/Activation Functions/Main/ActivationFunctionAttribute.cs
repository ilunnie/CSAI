using System;

namespace CSAI.Net.ActivationFunctions;

[AttributeUsage(AttributeTargets.Method)]
public class ActivationFunctionAttribute : Attribute
{
    public string[] FunctionNames { get; }

    public ActivationFunctionAttribute(params string[] functionNames)
        => FunctionNames = functionNames;
}