// Четем числото като текст
string number = Console.ReadLine(); // "4532"

int sumFactorials = 0;

// Обикаляме числото цифра по цифра
foreach (var digit in number)
{
    // Обръщаме си текущата цифра от char kъм integer
    int currentDigit = int.Parse(digit.ToString());

    // Проверяваме дали текущата цифра дали е четна
    if (currentDigit % 2 == 0)
    {
        sumFactorials += Factorial(currentDigit);
    }
}

Console.WriteLine(sumFactorials);

// Метод който изчислява факториел от дадено число
static int Factorial(int n)
{
    if (n == 0 || n == 1)
        return 1;

    int factorial = 1;

    for (int i = 2; i <= n; i++)
    {
        factorial *= i;
    }

    return factorial;
}