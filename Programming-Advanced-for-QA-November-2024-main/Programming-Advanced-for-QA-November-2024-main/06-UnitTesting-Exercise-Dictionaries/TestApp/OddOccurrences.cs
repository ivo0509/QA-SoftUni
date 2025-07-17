using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class OddOccurrences
{
    public static string FindOdd(string[] input)
    {
        Dictionary<string, int> oddWords = new();

        foreach (string word in input)
        {
            string wordLower = word.ToLower();

            oddWords.TryAdd(wordLower, 0);
            oddWords[wordLower]++;
        }

        StringBuilder sb = new();
        foreach (KeyValuePair<string, int> word in oddWords)
        {
            if (word.Value % 2 != 0)
            {
                sb.Append($"{word.Key} ");
            }
        }

        return sb.ToString().Trim();
    }
}
