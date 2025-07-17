using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class CountRealNumbers
{
    public static string Count(int[] nums)
    {
        SortedDictionary<int, int> count = new();

        foreach (int num in nums)
        {
            count.TryAdd(num, 0);
            count[num]++;
        }

        StringBuilder sb = new();
        foreach (KeyValuePair<int, int> pair in count)
        {
            sb.AppendLine($"{pair.Key} -> {pair.Value}");
        }

        return sb.ToString().Trim();
    }
}
