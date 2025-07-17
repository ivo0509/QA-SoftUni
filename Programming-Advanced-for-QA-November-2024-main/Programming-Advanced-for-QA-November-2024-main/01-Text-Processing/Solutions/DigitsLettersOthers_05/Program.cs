using System.Text;

//1. входни данни
string text = Console.ReadLine(); //"Agd#53Dfg^&4F53"

//цифри
StringBuilder sbDigits = new StringBuilder();

//букви (главни и малки)
StringBuilder sbLetters = new StringBuilder();

//други символи
StringBuilder sbOthers = new StringBuilder();

foreach(char symbol in text)
{
    //проверка дали цифра или буква
    //symbol = 'A'

    if (char.IsLetter(symbol))
    {
        sbLetters.Append(symbol);
    }
    else if (char.IsDigit(symbol))
    {
        sbDigits.Append(symbol);
    }
    else
    {
        sbOthers.Append(symbol);
    }
}

//sbDigits -> всички цифри от текста
//sbLetters -> всички букви от текста
//sbOthers -> всички останали символи

Console.WriteLine(sbDigits);
Console.WriteLine(sbLetters);
Console.WriteLine(sbOthers);
