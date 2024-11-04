using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class ListSplitter
{
    public static (List<int> evens, List<int> odds) SplitEvenAndOdd(List<int> list)
    {
        List<int> evenList = new List<int>();
        List<int> oddList = new List<int>();

        foreach (int value in list)
        {
            if (value % 2 == 0)
            {
                evenList.Add(value);
            }
            else
            {
                oddList.Add(value);
            }
        }

        return (evenList, oddList);
    }
}
