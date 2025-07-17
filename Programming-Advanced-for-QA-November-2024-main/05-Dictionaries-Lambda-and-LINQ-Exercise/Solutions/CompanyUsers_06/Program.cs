//компания -> списък със служители
Dictionary<string, List<string>> companyEmployees = new Dictionary<string, List<string>>();

//входни данни
string input = Console.ReadLine();


while (input != "End")
{
    //input = "SoftUni -> AA12345"
    //input.Split(" -> ") -> ["SoftUni", "AA12345"]
    string companyName = input.Split(" -> ")[0]; //"SoftUni"
    string employeeId = input.Split(" -> ")[1]; //"AA12345"


    //срещали до момента тази компания -> добавим въведения служител към списъка
    if (companyEmployees.ContainsKey(companyName))
    {
        List<string> currentEmployees = companyEmployees[companyName];
        if (!currentEmployees.Contains(employeeId))
        {
            currentEmployees.Add(employeeId);
        }
    }
    //не сме срещали до момента тази компания
    else
    {
        companyEmployees.Add(companyName, new List<string>() { employeeId });
    }

    input = Console.ReadLine();
}

//companyEmployees: key (име на компания) -> value (списък със служителите)
foreach(KeyValuePair<string, List<string>> entry in companyEmployees)
{
    //всеки един запис се съхранява в променилива entry
    //entry.Key -> име на компания
    Console.WriteLine(entry.Key);

    //entry.Value -> списък със служителите -> {"AA12345", "BB12345", "CC12345"}

    //начин 1:
    //entry.Value.ForEach(employee => Console.WriteLine("-- " + employee));

    //начин 2:
    foreach(string employee in entry.Value)
    {
        Console.WriteLine("-- " + employee);
    }

}

