//входни данни
int countCommands = int.Parse(Console.ReadLine());

List<string> guestsList = new List<string>();

for (int count = 1; count <= countCommands; count++)
{
    string command = Console.ReadLine();
    string[] commandParts = command.Split(" ");
    string name = commandParts[0]; //име на гост

    //проверка коя команда сме въвели
    if (commandParts.Length == 3)
    {
        //1. command = "Desi is going!".Split(" ") -> ["Desi", "is", "going!"] -> 3 елемента
        //госта го има в списъка
        if (guestsList.Contains(name))
        {
            Console.WriteLine($"{name} is already in the list!");
        }
        //госта не е в списъка
        else
        {
            guestsList.Add(name);
        }

    }
    else if (commandParts.Length == 4)
    {
        //2. command = "Desi is not going!".Split(" ") -> ["Desi", "is", "not", "going!"] -> 4 елемента
        //госта го има в списъка
        if (guestsList.Contains(name))
        {
            guestsList.Remove(name);
        }
        //госта го няма в списъка
        else
        {
            Console.WriteLine($"{name} is not in the list!");
        }
    }
}

foreach (string guestName in guestsList)
{
    Console.WriteLine(guestName);
}




