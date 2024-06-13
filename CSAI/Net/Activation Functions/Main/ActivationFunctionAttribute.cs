using System;

namespace CSAI.Net.ActivationFunctions;

[AttributeUsage(AttributeTargets.Method)]
public class ActivationFunctionAttribute : Attribute
{
    public string[] FunctionNames { get; }

    public ActivationFunctionAttribute(string functionName)
        => FunctionNames = new string[]{functionName};
    public ActivationFunctionAttribute(string[] functionNames)
        => FunctionNames = functionNames;
}