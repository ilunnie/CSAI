using System;
using System.Linq;
using System.Reflection;

namespace CSAI.Net.ActivationFunctions;

public static partial class ActivationFunctions
{
    public static Func<double, double> GetFunction(string name, object[] parameters)
    {
        MethodInfo[] methods = typeof(ActivationFunctions).GetMethods();
        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<ActivationFunctionAttribute>();
            var methodParameters = method.GetParameters();
            if (attribute != null && attribute.FunctionName == name && methodParameters.Length == parameters.Length)
            {
                var types = methodParameters.Select(p => p.ParameterType).ToArray();
                if (types.SequenceEqual(parameters.Select(p => p.GetType())))
                    return (x) => (double)method.Invoke(null, parameters);
            }
        }
        throw new InvalidActionFunctionName($"Action Function {name} not found or params invalid");
    }

    public static Func<double, double> GetFunction(string name, string parameters)
        => GetFunction(name, parameters.Split(",").Select(s => s.Trim()).ToArray());

    public static Func<double, double> FromString(string text)
    {
        string[] splitted = text.Split(",").Select(s => s.Trim()).ToArray();
        string name = splitted[0];
        string[] paramsArray = splitted.Skip(1).ToArray();
        return GetFunction(name, paramsArray);
    }

    public static Func<double, double> ToActivationFunction(this string text)
        => FromString(text);
}