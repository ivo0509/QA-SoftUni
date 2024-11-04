using System;

namespace TestApp;

public class LongestIncreasingSubsequence
{
    public static string GetLis(int[]? arr)
    {
        if (arr is null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        int[] length = new int[arr.Length];
        int[] previous = new int[arr.Length];
        int maxLength = 0;
        int maxIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            length[i] = 1;
            previous[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (arr[j] >= arr[i] || length[j] + 1 <= length[i])
                {
                    continue;
                }

                length[i] = length[j] + 1;
                previous[i] = j;
            }

            if (length[i] > maxLength)
            {
                maxLength = length[i];
                maxIndex = i;
            }
        }

        int[] sequence = new int[maxLength];
        int current = maxIndex;

        for (int i = maxLength - 1; i >= 0; i--)
        {
            sequence[i] = arr[current];
            current = previous[current];
        }

        return string.Join(" ", sequence);
    }
}
