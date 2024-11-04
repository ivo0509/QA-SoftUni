namespace TestApp;

public class PascalTriangle
{
    public static string PrintTriangle(int n)
    {
        string result = string.Empty;
        for (int line = 0; line < n; line++)
        {
            int number = 1;
            for (int j = 0; j <= line; j++)
            {
                result += $"{number} ";
                number = number * (line - j) / (j + 1);
            }

            result += "\n";
        }

        return result;
    }
}
