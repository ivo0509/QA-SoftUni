// Четем числото като Integer
int number = int.Parse(Console.ReadLine()); 

int sumFactorials = 0;

while (number > 0)
{
    // Вземам последната цифра от числото
    int lastDigit = number % 10;

    // Проверяваме дали текущата цифра дали е четна
    if (lastDigit % 2 == 0)
    {
        sumFactorials += Factorial(lastDigit);
    }

    // Премахваме последната цифра
    number /= 10;
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
