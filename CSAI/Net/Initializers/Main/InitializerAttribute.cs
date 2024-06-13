using System;

namespace CSAI.Net.Initializers;

[AttributeUsage(AttributeTargets.Method)]
public class InitializerAttribute : Attribute
{
    public string[] InitializerNames { get; }
    
    public InitializerAttribute(params string[] initializerNames)
        => InitializerNames = initializerNames;
}