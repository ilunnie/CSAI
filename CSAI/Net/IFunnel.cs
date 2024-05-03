namespace CSAI.Net;

/// <summary>
/// Interface that receives and returns values
/// </summary>
public interface IFunnel<T>
{
    /// <summary>
    /// Values ​​received by the object
    /// </summary>
    T[] Input { get; set; }

    /// <summary>
    /// Object data output
    /// </summary>
    T[] Output();
}