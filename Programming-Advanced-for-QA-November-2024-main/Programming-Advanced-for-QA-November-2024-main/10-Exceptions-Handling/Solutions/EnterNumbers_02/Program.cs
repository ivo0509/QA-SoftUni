int start = 1; //начало на диапазона
int end = 100; //край на диапазона - винаги е 100

List<int> numbers = new List<int>(); //всички въведени числа, които отговарят на условието

//повтаряме: въвежда валидно цяло число
//стоп: имаме 10 валидни числа в списъка (брой >= 10)
//продължаваме: нямаме все още 10 валидни числа в списъка (брой < 10)
while (numbers.Count < 10)
{
    try
    {
        int number = ReadNumber(start, end);
        //ReadNumber
        //1. ArgumentException -> въведеното число не е в диапазона
        //2. FormatException -> въведените входни данни не са число
        //3. връщаме валидно число
        numbers.Add(number);
        start = number; //следващото число ще е в диапазон: (предишното въведено; 100)
    }
    catch (ArgumentException argEx)
    {
        Console.WriteLine(argEx.Message);
    }
    catch (FormatException formatEx)
    {
        Console.WriteLine(formatEx.Message);
    }
}

//списък с валидни числа
Console.WriteLine(String.Join(", ", numbers));


//метод, който връща цяло число, което е въведено, в диапазона от (start, end)
static int ReadNumber (int start, int end)
{
    //1. въвеждаме входни данни (текст)
    string input = Console.ReadLine();

    //2. проверка дали входните данни са число
    try
    {
        int number = int.Parse(input); //ако тук получим FormatException -> входните данни не са число
        //въведените входни данни са число, което съхраняваме в променливата number
        //3. проверка дали числото е в диапазона
        if (number > start && number < end)
        {
            //валидно число
            return number;
        }
        else
        {
            //невалидно
            throw new ArgumentException($"Your number is not in range {start} - {end}!"); //даваме сигнал, че числото е невалидно
        }
    }
    catch (FormatException)
    {
        //входните данни не са число
        throw new FormatException("Invalid Number!");
    }
    
}



