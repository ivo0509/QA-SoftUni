//Dictionary / Речник -> съвкупност от еднотипни записи

//речник за телефонен указател
Dictionary<string, string> phonebook = new Dictionary<string, string>(); //нов празен речник

//добавяне на записи в речника (телефонен указател)
//начин 1: Add
phonebook.Add("Ivan", "+359886543782");
phonebook.Add("Georgi", "+359887654325");

//начин 2
phonebook["Peter"] = "+359882345123";
phonebook["Misho"] = "+359889237612";

//създаване на речник с предварително зададени записи
Dictionary<string, int> fruits = new()
{
    { "Kiwi", 3 },
    { "Apple", 5 }
};

//премахваме записи от речника
phonebook.Remove("Peter");

//ContainsKey и ContainsValue -> връщат true или false
bool containsCheck = phonebook.ContainsKey("Ivan");

Console.WriteLine(phonebook.ContainsKey("Ivan"));
Console.WriteLine(phonebook.ContainsKey("Boris"));

if (phonebook.ContainsKey("Georgi"))
{
    Console.WriteLine("Hello, Georgi");
}

//брой на записите
int count = phonebook.Count;
Console.WriteLine(phonebook.Count);


//SortedDictionary - вид речник, в който при добавяне записите се сортират в нарастващ ред спрямо ключа им
//ученик -> оценка
SortedDictionary<string, double> students = new SortedDictionary<string, double>();
students.Add("Ivan", 5.60);
students.Add("Alex", 4.50);
students.Add("Georgi", 5.90);
students.Add("Martin", 5.35);


//обхождане на речник
//начин 1
foreach (KeyValuePair<string, double> entry in students)
{
    //запис -> entry
    //entry.Key -> име на студента
    //entry.Value -> оценка
    Console.WriteLine(entry.Key + " " + entry.Value);
}

//начин 2
//students.Keys -> съвкупност от ключовете в речника
//students.Values -> съвкупност от стойностите в речника
foreach(string key in students.Keys)
{
    Console.WriteLine(key + " " + students[key]);
}



//достъпване на запис от речник
Console.WriteLine(phonebook["Ivan"]);
