using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp;

public class Plants
{
    public static string GetFastestGrowing(string[] plants)
    {
        Dictionary<int, List<string>> groupedPlants = new();

        foreach (string plant in plants)
        {
            int length = plant.Length;
            groupedPlants.TryAdd(length, new List<string>());
            groupedPlants[length].Add(plant);
        }

        StringBuilder sb = new();
        foreach (KeyValuePair<int, List<string>> kvp in groupedPlants.OrderBy(kv => kv.Key))
        {
            sb.AppendLine($"Plants with {kvp.Key} letters:");
            foreach (string plant in kvp.Value)
            {
                sb.AppendLine(plant);
            }
        }

        return sb.ToString().Trim();
    }
}
