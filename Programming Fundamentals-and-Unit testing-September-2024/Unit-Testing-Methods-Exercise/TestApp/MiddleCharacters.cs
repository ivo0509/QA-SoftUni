using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class MiddleCharacters
{
    public static string GetMiddleChars(string input)
    {
        int length = input.Length;
        
        if(string.IsNullOrWhiteSpace(input))
        {
            return "Empty string";
        }

        if(length % 2 == 0)
        {
            return input.Substring((length / 2) - 1, 2);
        }
        else
        {
            return input.Substring(length / 2, 1);
        }
    }
}
