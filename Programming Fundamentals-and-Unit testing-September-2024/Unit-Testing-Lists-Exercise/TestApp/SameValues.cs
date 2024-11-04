using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class SameValues
{
    public static List<int> FindSameValues(List<int> firstList, List<int> secondList)
    {
        List<int> repeatingValues = new List<int>();

        foreach (int value in firstList)
        {
            if (secondList.Contains(value) && !repeatingValues.Contains(value))
            {
                repeatingValues.Add(value);
            }
        }

        return repeatingValues;
    }
}

