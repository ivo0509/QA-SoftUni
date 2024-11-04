using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class TopIntegers
{
    public string FindTopIntegers(int[] nums)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < nums.Length; i++)
        {
            bool topInt = true;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] <= nums[j])
                {
                    topInt = false;
                    break;
                }
            }
            if (topInt)
                sb.Append(nums[i] + " ");
        }

        return sb.ToString().TrimEnd();
    }
}
