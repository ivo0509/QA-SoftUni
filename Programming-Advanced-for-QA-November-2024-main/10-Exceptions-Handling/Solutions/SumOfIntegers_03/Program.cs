//входни данни
string input = Console.ReadLine(); //"2147483649 2 3.4 5 invalid 24 -4"
string[] elements = input.Split(); //["2147483649", "2", "3.4", "5", "invalid", "24", "-4"]

//намираме сумата на целите числа в масива
int sum = 0; //сумата на всички въведени цели числа

foreach(string element in elements)
{
    //1. проверка дали елемента ми е число
    //2. проверка дали числото може да се съхрани в int променлива

    try
    {
        int number = int.Parse(element);
        //FormatException -> елементът ми не е число
        //OverflowException -> елементът ми е много голямо число, което не мога да съхраня в променлива от тип int
        sum += number;
    }
    catch (FormatException)
    {
        //елементът ми не е цяло число
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch (OverflowException)
    {
        //елементът е число, което не мoже да се съхрани в int променлива
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
    }
}

//обходили всички въведени елементи
Console.WriteLine($"The total sum of all integers is: {sum}");



