using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class ListRemover
{
    public static List<int> RemoveElementsGreaterThan(List<int> list, int threshold)
    {
        List<int> resultList = new List<int>();

        foreach (int value in list)
        {
            if (value <= threshold)
            {
                resultList.Add(value);
            }
        }

        return resultList;
    }

    public static List<int> RemoveElementsLessThanOrEqualTo(List<int> list, int threshold)
    {
        List<int> resultList = new List<int>();

        foreach (int value in list)
        {
            if (value > threshold)
            {
                resultList.Add(value);
            }
        }

        return resultList;
    }
}
