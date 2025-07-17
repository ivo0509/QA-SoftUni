string[] wordsWithEvenLength = Console.ReadLine()                     //"kiwi orange banana apple"
                  .Split(" ")                           //["kiwi", "orange", "banana", "apple"]
                  .Where(text => text.Length % 2 == 0)  //["kiwi", "orange", "banana"]
                  .ToArray();



foreach(string word in wordsWithEvenLength)
{
    Console.WriteLine(word);
}