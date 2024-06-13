using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace CSAI.Net.ActivationFunctions;

public static partial class ActivationFunctions
{
    public static Func<double, double> GetFunction(string name, object[] parameters)
    {
        name = name.ToUpper();
        MethodInfo[] methods = typeof(ActivationFunctions).GetMethods();
        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<ActivationFunctionAttribute>();
            var methodParameters = method.GetParameters();
            if (attribute != null && attribute.FunctionNames.Select(n => n.ToUpper()).Contains(name) && methodParameters.Length == parameters.Length + 1)
            {
                var types = methodParameters.Skip(1).Select(p => p.ParameterType).ToArray();
                var length = parameters.Length;
                var convertedParams = new object[length];

                bool canConvert = true;
                for (int i = 0; i < parameters.Length; i++)
                {
                    try
                    {
                        convertedParams[i] = Convert.ChangeType(parameters[i], types[i], CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        canConvert = false;
                        break;
                    }
                }

                if (canConvert)
                    return (x) =>
                    {
                        object[] methodParametersWithDouble = new object[methodParameters.Length];
                        methodParametersWithDouble[0] = x;
                        Array.Copy(convertedParams, 0, methodParametersWithDouble, 1, convertedParams.Length);
                        return (double)method.Invoke(null, methodParametersWithDouble);
                    };
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