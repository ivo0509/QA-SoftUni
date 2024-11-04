using System.Collections.Generic;
using System.Linq;

namespace TestApp;

public class Duplicates
{
    public static int[] RemoveDuplicates(int[] numbers)
    {
        HashSet<int> uniqueNumbers = new();

        foreach (int number in numbers)
        {
            uniqueNumbers.Add(number);
        }

        return uniqueNumbers.ToArray();
    }
}
