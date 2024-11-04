using System.Linq;

namespace TestApp;

public class Reverser
{
    public static string[] ReverseStrings(string[] arr)
    {
        return arr.Select(s => new string(s.Reverse().ToArray())).ToArray();
    }
}
