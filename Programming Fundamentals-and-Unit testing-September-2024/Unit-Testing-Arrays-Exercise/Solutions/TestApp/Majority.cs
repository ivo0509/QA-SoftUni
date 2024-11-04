using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class Majority
{
    public static int IsEvenOrOddMajority(int[] nums)
    {
        int even = 0;
        int odd = 0;

        foreach (int num in nums)
        {
            if (num == 0)
            {
                continue;
            }

            if (num % 2 == 0)
            {
                even++;
            }
            else
            {
                odd++;
            }
        }

        return even - odd;
    }
}
