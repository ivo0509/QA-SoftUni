using System;
using System.Linq;

namespace TestApp;

public class Fake
{
    public static char[] RemoveStringNumbers(char[]? arr)
    {
        return arr.Where(c => !char.IsDigit(c)).ToArray();
    }
}
