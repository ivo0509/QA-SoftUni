//входни данни -> думи разделени с интервал

string[] words = Console.ReadLine() //"Java C# PHP PHP JAVA C java"
                 .Split(" ");      //["Java", "C#", "PHP", "PHP", "JAVA", "C", "java"]

//запис: дума -> бр. срещания
Dictionary<string, int> wordsCount = new Dictionary<string, int>();


foreach(string word in words)
{
    //думата я правим с изцяло малки букви
    string wordWithLowerCase = word.ToLower();

    if (!wordsCount.ContainsKey(wordWithLowerCase))
    {
        //думата я срещам за първи път
        wordsCount.Add(wordWithLowerCase, 1);
    }
    else
    {
        //вече сме я срещали -> увеличаваме бр. срещания с 1
        wordsCount[wordWithLowerCase]++;
    }
}

//запис: key (дума с малки букви) -> value (бр. срещания)
foreach(KeyValuePair<string, int> entry in wordsCount)
{
    //entry
    //entry.Key -> дума с малки букви
    //entry.Value -> бр. срещания
    int countOccurences = entry.Value;
    if (countOccurences % 2 != 0)
    {
        Console.Write(entry.Key + " ");
    }
}