//полезно изкопаемо -> количество
Dictionary<string, int> resourcesQuantity = new Dictionary<string, int>();

//входни данни -> име на полезно изкопаемо или "stop"

//повтаряме: въвеждаме имена на полезни изкопаеми + въвеждаме неговата стойност
//цикъл: while
//спираме: входни данни == "end"
//продължаваме: входни данни != "end"

string resource = Console.ReadLine(); //име на полезно изкопаемо или "stop"

while (resource != "stop")
{
    int quantity = int.Parse(Console.ReadLine());

    //име на полезно изкопаемо -> resource
    //количество на полезно изкопаемо -> quantity

    //1. вече да съм го срещала това полезно изкопаемо
    if (resourcesQuantity.ContainsKey(resource))
    {
        resourcesQuantity[resource] += quantity;
    }
    //2. все още не сме среща такова полезно изкопаемо
    else
    {
        resourcesQuantity.Add(resource, quantity);
    }

    resource = Console.ReadLine();
}


//resourcesQuantity: полезно изкопаемо (key) -> количество (value)
foreach(KeyValuePair<string, int> entry in resourcesQuantity)
{
    //всеки един запис се съхранява в entry
    //entry.Key -> име на полезно изкопаемо
    //entry.Value -> количество на полезно изкопаемо
    Console.WriteLine(entry.Key + " -> " + entry.Value); 
}


