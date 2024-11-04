//входни данни

List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
//numbers = {4, 19, 2, 53, 6, 43}

string command = Console.ReadLine(); //"end" или друга валидна команда
//повтарям: въвеждам команди
//стоп: въведената команда == "end"
//продължавам: въведената команда != "end"

while (command != "end")
{
    //command имам валидна команда
    string[] commandParts = command.Split(" ");
    string commandName = commandParts[0]; //"Add", "Remove", "RemoveAt", "Insert"

    //прверка коя команда ми я въведена
    switch (commandName)
    {
        case "Add":
            //add a number to the end of the list
            //1. command = "Add 3".Split(" ") -> ["Add", "3"]
            int numberToAdd = int.Parse(commandParts[1]);
            numbers.Add(numberToAdd);
            break;

        case "Remove":
            //remove first occurence number from the list
            //2. command = "Remove 6".Split(" ") -> ["Remove", "6"]
            int numberToRemove = int.Parse(commandParts[1]);
            numbers.Remove(numberToRemove);
            break;

        case "RemoveAt":
            //remove a number at a given index
            //3. command = "RemoveAt 0".Split(" ")  -> ["RemoveAt", "0"]
            int positionForRemove = int.Parse(commandParts[1]);
            numbers.RemoveAt(positionForRemove);
            break;

        case "Insert":
            //insert a number at a given index
            //4. command = "Insert 12 1".Split(" ") -> ["Insert", "12", "1"]
            int numberToInsert = int.Parse(commandParts[1]);
            int positionToInsert = int.Parse(commandParts[2]);
            numbers.Insert(positionToInsert, numberToInsert);
            break;
    }

    command = Console.ReadLine();
}

//принтираме елементите на списъка разделени с интервал
Console.WriteLine(string.Join(" ", numbers));


