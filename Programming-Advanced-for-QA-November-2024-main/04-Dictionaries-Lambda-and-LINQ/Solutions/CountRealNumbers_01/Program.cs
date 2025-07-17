//входни данни -> масив от дробни числа

double[] numbers = Console.ReadLine()    //"1 5 1 3"
                   .Split(" ")           //["1", "5", "1", "3"]
                   .Select(double.Parse) //[1, 5, 1, 3]
                   .ToArray();


//key (число) -> value (бр. срещания)
SortedDictionary<double, int> countOccurences = new SortedDictionary<double, int>();


foreach(double number in numbers)
{
    //проверка дали това число вече срещано

    if (countOccurences.ContainsKey(number))
    {
        //вече имам записано числото с някакъв брой срещания
        //увеличаваме броя на срещанията с 1
        countOccurences[number]++;
    }
    else
    {
        //не сме срещали моето число до момента -> срещаме за първи път
        countOccurences.Add(number, 1);
    }
}

//запис: key (число) -> value (бр. срещания)
foreach(KeyValuePair<double, int> entry in countOccurences)
{
    //всеки един запис се съхранява в entry
    //entry.Key -> число
    //entry.Value -> бр . срещания
    Console.WriteLine(entry.Key + " -> " + entry.Value);
}