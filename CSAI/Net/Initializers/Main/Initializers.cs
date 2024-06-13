using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CSAI.Net.Initializers;

public static partial class Initializers
{
    private static Random Random = new Random();
    public static Func<double> GetFunction(string name, params object[] parameters)
    {
        name = name.ToUpper();
        MethodInfo[] methods = typeof(Initializers).GetMethods();
        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<InitializerAttribute>();
            var methodParameters = method.GetParameters();
            if (
                attribute != null && 
                attribute.InitializerNames.Select(n => n.ToUpper()).Contains(name) &&
                methodParameters.Length == parameters.Length
                )
            {
                var types = methodParameters.Select(p => p.ParameterType).ToArray();
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
                    return () => (double)method.Invoke(null, convertedParams);
            }
        }
        throw new InvalidInitializer($"Initializer \"{name}\" not found or params invalid");
    }

    public static Func<double> GetFunction(string name, string parameters)
        => GetFunction(name, parameters.Split(",").Select(s => s.Trim()).ToArray());

    public static Func<double> FromString(string text)
    {
        string[] splitted = text.Split(",").Select(s => s.Trim()).ToArray();
        string name = splitted[0];
        string[] paramsArray = splitted.Skip(1).ToArray();
        return GetFunction(name, paramsArray);
    }

    public static Func<double> ToInitializer(this string text)
        => FromString(text);
}