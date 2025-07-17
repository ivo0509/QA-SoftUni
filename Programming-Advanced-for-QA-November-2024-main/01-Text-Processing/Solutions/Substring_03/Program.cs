//1. входни данни
string wordToRemove = Console.ReadLine(); //дума, която ще премахвам
string sentence = Console.ReadLine(); //изречение, от което ще премахвам дадената дума

//wordToRemove = "ice"
//sentence = "kicegiciceeb"

//повтаряме: премахваме дадената дума от изречението
//while цикъл
//stop: в изречението нямаме думата за премахване 
//continue: в изречението имаме думата за премахване

//докато намираме думата в текста
while (sentence.Contains(wordToRemove))
{
    //в изречението имаме думата за премахване
    int positionWord = sentence.IndexOf(wordToRemove);
    sentence = sentence.Remove(positionWord, wordToRemove.Length);
}

Console.WriteLine(sentence);




