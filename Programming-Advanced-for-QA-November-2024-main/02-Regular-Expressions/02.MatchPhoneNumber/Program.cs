
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"\+359([ |-])2\1\d{3}\1\d{4}\b";

MatchCollection matches = Regex.Matches(input, pattern);

Console.WriteLine(string.Join(", ", matches));
