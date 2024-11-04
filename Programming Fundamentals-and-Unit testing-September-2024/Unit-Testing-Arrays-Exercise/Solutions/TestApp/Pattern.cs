using System;
using System.Linq;

namespace TestApp;

public class Pattern
{
    public static int[] SortInPattern(int[]? arr)
    {
      
        Array.Sort(arr);

        int[] distinctList = arr.Distinct().ToArray();

        int[] result = new int[distinctList.Length];
        int left = 0;
        int right = distinctList.Length - 1;
        bool isLeftTurn = true;

        for (int i = 0; i < distinctList.Length; i++)
        {
            if (isLeftTurn)
            {
                result[i] = distinctList[left];
                left++;
            }
            else
            {
                result[i] = distinctList[right];
                right--;
            }

            isLeftTurn = !isLeftTurn;
        }

        return result;
    }
}
