//повтаряме: въвеждаме входни данни (текст)
//while цикъл -> не знаем колко точно пъти повтаряме
//стоп: входни данни == "end"
//продължаваме: входни данни != "end"

string input = Console.ReadLine();

while (input != "end")
{
    //input = "helLo" -> reverse -> "oLleh"
    //1. обръщаме текста
    string reversedText = ""; //обърнатия текст
    //всички символи от последния към първия
    for (int position = input.Length - 1; position >= 0; position--)
    {
        char currentSymbol = input[position];
        reversedText += currentSymbol;
        //reversedText = reversedText + currentSymbol;
    }

    //input = "helLo" -> текст в прав ред
    //reversedText = "oLleh" -> текст в обърнат ред

    //2. отпечатваме
    Console.WriteLine($"{input} = {reversedText}");


    //въвеждаме си следващите входни данни / дума
    input = Console.ReadLine();
}


