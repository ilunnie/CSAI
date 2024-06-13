using System;

namespace CSAI.Net.Initializers;

public class InvalidInitializer : Exception
{
    public InvalidInitializer(string message) : base(message) {}
}