List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

string command = Console.ReadLine();

while (command != "End")
{
    string[] commandParts = command.Split(" ");
    string commandName = commandParts[0]; //"Add", "Insert", "Remove", "Shift"

    switch (commandName)
    {
        case "Add":
            //add a number to the end of the list
            //1. command = "Add 3".Split(" ") -> ["Add", "3"]
            int numberToAdd = int.Parse(commandParts[1]);
            numbers.Add(numberToAdd);
            break;
        case "Insert":
            //insert a number at a given index
            //2. command = "Insert 12 1".Split(" ") -> ["Insert", "12", "1"]
            int numberToInsert = int.Parse(commandParts[1]);
            int positionToInsert = int.Parse(commandParts[2]);
            //проверка дали е валидна позицията -> само тогва вмъкваме елемент
            if (positionToInsert >= 0 && positionToInsert <= numbers.Count - 1)
            {
                numbers.Insert(positionToInsert, numberToInsert);
            }
            else
            {
                //невалидна позиция
                Console.WriteLine("Invalid index");
            }
            break;
        case "Remove":
            //remove first occurence number from the list
            //3. command = "Remove 6".Split(" ") -> ["Remove", "6"]
            int positionToRemove = int.Parse(commandParts[1]);
            //проверка дали е валидна позицията -> само тогва вмъкваме елемент
            if (positionToRemove >= 0 && positionToRemove <= numbers.Count - 1)
            {
                numbers.RemoveAt(positionToRemove);
            }
            else
            {
                //невалидна позиция
                Console.WriteLine("Invalid index");
            }
            break;
        case "Shift":
            string position = commandParts[1]; //"left" или "right"
            int count = int.Parse(commandParts[2]); //брой пъти на преместване
            if (position == "left")
            {
                //4. command = "Shift left 2".Split(" ") -> ["Shift", "left", "2"]
                //first number becomes last
                //numbers = {1, 23, 29, 18, 43, 21, 20, 1}
                for (int i = 1; i <= count; i++)
                {
                    int firstNumber = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Add(firstNumber);
                }

            }
            else if (position == "right")
            {
                //5. command = "Shift right 3".Split(" ") -> ["Shift", "right", "3"]
                //last number becomes first
                //numbers = {20, 1, 23, 29, 18, 43, 21}
                for (int i = 1; i <= count; i++)
                {
                    int lastNumber = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Insert(0, lastNumber);
                }
            }
            break;

    }

    command = Console.ReadLine();
}


//принтираме елементите на списъка разделени с интервал
Console.WriteLine(string.Join(" ", numbers));