//паркинг с коли
//собственик -> номер на автомобила
Dictionary<string, string> parking = new Dictionary<string, string>();


int countCommands = int.Parse(Console.ReadLine()); //брой команди

//повтаряме: въвеждаме команда
//цикъл -> for

for (int count = 1; count <= countCommands; count++)
{
    string command = Console.ReadLine(); //текст на командa

    //проверка коя команда е въведена
    if (command.Contains("unregister"))
    {
        //излизане от паркинга -> отписване от паркинга
        //command = "unregister Desislava"
        //command.Split() -> ["unregister", "Desislava"]
        string ownerOut = command.Split(" ")[1]; 
        //проверка дали имаме такъв собственик
        if (!parking.ContainsKey(ownerOut))
        {
            //несъществуващ собственик
            Console.WriteLine($"ERROR: user {ownerOut} not found");
        }
        else
        {
            //имам собственик в паркинг
            parking.Remove(ownerOut);
            Console.WriteLine($"{ownerOut} unregistered successfully");
        }


    }
    else if (command.Contains("register"))
    {
        //влизане в паркинга -> регистрация в паркинга
        //command = "register Desislava CВ4664PP"
        //command.Split() -> ["register", "Desislava", "CВ4664PP"]
        string owner = command.Split()[1];
        string carNumber = command.Split()[2];

        //проверка дали този собственик има вече кола в паркинга
        if (!parking.ContainsKey(owner))
        {
            //нямаме записан такъв собственик
            parking.Add(owner, carNumber);
            Console.WriteLine($"{owner} registered {carNumber} successfully");
        }
        else
        {
            //имаме вече такъв собственик
            Console.WriteLine($"ERROR: already registered with plate number {parking[owner]}");
        }    

    }
}

//речник (паркинг) със записи (собственик -> номер на колата)
foreach(KeyValuePair< string, string> entry in parking)
{
    //entry
    //entry.Key -> собственик
    //entry.Value -> номер на колата
    Console.WriteLine(entry.Key + " => " + entry.Value);
}




