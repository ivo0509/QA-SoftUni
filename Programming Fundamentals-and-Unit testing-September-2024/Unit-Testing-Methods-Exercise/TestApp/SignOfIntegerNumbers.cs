using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class SignOfIntegerNumbers
{
    public static string CheckSign(string number)
    {
        int num = 0;

        if (int.TryParse(number, out num) == false)
        {
            return "The input is not an integer!";
        }

        if (num > 0)
        {
            return $"The number {number} is positive.";
        }
        else if (num < 0)
        {
            return $"The number {number} is negative.";
        }
        else
        {
            return $"The number {number} is zero.";
        }
    }
}

