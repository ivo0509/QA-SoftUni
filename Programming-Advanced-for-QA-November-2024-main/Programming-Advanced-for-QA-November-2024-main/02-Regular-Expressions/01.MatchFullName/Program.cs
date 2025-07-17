
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

MatchCollection matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
    Console.Write(match + " ");
}
