//запис: key(дума) -> value(списък със синоними)
Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

int countWords = int.Parse(Console.ReadLine()); //брой на думите

for (int count = 1; count <= countWords; count++)
{
    string word = Console.ReadLine(); //стойността на думата
    string synonym = Console.ReadLine(); //синоним на думата

    if (wordSynonyms.ContainsKey(word))
    {
        //вече сме срещали думата -> добавяме новия синоним към текущия списък със синоними
        wordSynonyms[word].Add(synonym);
    }
    else
    {
        //за първи път срещаме думата
        wordSynonyms.Add(word, new List<string>());
        wordSynonyms[word].Add(synonym);
    }

}

//wordSynonyms имаме думите и техните синоними
//запис: key (дума) -> value (списък със синоними)
foreach(KeyValuePair<string, List<string>> entry in wordSynonyms)
{
    //всеки един запис се съхранява в entry
    //entry.Key -> дума (string)
    //entry.Value -> списък със синоними (List<string>)
    string word = entry.Key;
    List<string> synonyms = entry.Value;
    Console.WriteLine(word + " - " + string.Join(", ", synonyms));
}