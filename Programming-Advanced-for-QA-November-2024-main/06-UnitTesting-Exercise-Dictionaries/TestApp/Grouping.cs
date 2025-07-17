using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp;

public class Grouping
{
    public static string GroupNumbers(List<int> nums)
    {
        Dictionary<string, List<int>> grouped = nums
            .GroupBy(n => n % 2 == 0 ? "Even" : "Odd")
            .ToDictionary(g => g.Key, g => g.ToList());

        StringBuilder sb = new();
        foreach (KeyValuePair<string, List<int>> group in grouped)
        {
            sb.AppendLine($"{group.Key} numbers: {string.Join(", ", group.Value)}");
        }

        return sb.ToString().Trim();
    }
}
