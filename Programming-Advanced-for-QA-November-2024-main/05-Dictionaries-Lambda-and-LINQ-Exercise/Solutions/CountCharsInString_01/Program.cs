//входни данни
string text = Console.ReadLine(); //"carrot"

//символ -> бр. срещания
Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

foreach (char symbol  in text)
{
    //1. проверка дали символът е интервал
    if (symbol == ' ')
    {
        continue;
    }

    //2. проверка дали символът сме го срещали до момента
    if (symbolsCount.ContainsKey(symbol))
    {
        //вече сме срещали тази буква -> увеличим текущия брой на срещанията
        symbolsCount[symbol]++;
    }
    else
    {
        //не сме срещали такава буква -> срещаме я за първи път
        symbolsCount.Add(symbol, 1);

    }
}


//symbolsCount
//запис: key (символ) -> value (бр. срещания)
foreach(KeyValuePair<char, int> entry in symbolsCount)
{
    //всеки един запис се съхранява в entry
    //entry.Key -> символ
    //entry.Value -> бр. срещания
    Console.WriteLine(entry.Key + " -> " + entry.Value);
}