using System.Text;

namespace TestApp;

public class ReverseConcatenate
{
    public static string ReverseAndConcatenateStrings(string[]? inputStrings)
    {
        if (inputStrings == null || inputStrings.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder reversedStrings = new();
        for (int i = inputStrings.Length - 1; i >= 0; i--)
        {
            reversedStrings.Append(inputStrings[i]);
        }

        return reversedStrings.ToString();
    }
}
