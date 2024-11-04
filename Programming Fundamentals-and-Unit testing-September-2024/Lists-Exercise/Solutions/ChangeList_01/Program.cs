//входни данни
List<int> numbers = Console.ReadLine() //"1 2 3 4 5 5 5 6"
                    .Split(" ")        //["1", "2", "3", "4", "5", "5", "5", "6"]
                    .Select(int.Parse) //[1, 2, 3, 4, 5, 5, 5, 6]
                    .ToList();         //{1, 2, 3, 4, 5, 5, 5, 6}

//повтаряме: въвеждаме входни данни ("end" или команда за модификация)
//стоп: входни данни == "end"
//продължаваме: входни данни != "end"

string input = Console.ReadLine();

while (input != "end")
{
    //input != "end" -> въведена валидна команда
    //1. input = "Delete 5".Split(" ")     -> ["Delete", "5"]
    //2. input = "Insert 10 1".Split(" ") -> ["Insert", "10", "1"]

    string[] commandParts = input.Split(" ");
    string commandName = commandParts[0]; //"Delete" или "Insert"

    //проверка коя команда ми е въведена
    if (commandName == "Delete")
    {
        int elementForDelete = int.Parse(commandParts[1]); //елемент, който трябва да изтрия от списъка
        //{1, 2, 3, 4, 5, 5, 5, 6} -> "Delete 5" -> {1, 2, 3, 4, 6}
        //начин 1:
        //numbers.RemoveAll(element => element == elementForDelete);

        //начин 2:
        while (numbers.Contains(elementForDelete))
        {
            numbers.Remove(elementForDelete);
        }
    }
    else if (commandName == "Insert")
    {
        int elementForInsert = int.Parse(commandParts[1]);
        int positionForInsert = int.Parse(commandParts[2]);
        //{1, 2, 3, 4, 5, 5, 5, 6} -> "Insert 102 1" -> {1, 102, 2, 3, 4, 5, 5, 5, 6}
        numbers.Insert(positionForInsert, elementForInsert);
    }

    input = Console.ReadLine();
}



//отпечатваме елементите на списъка разделени с интервал
Console.WriteLine(string.Join(" ", numbers));

