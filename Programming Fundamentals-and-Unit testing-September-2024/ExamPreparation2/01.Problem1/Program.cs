
int n = int.Parse(Console.ReadLine());

// Флаг за това дали съм намерил магическо число
bool isFound = false;

for (int num = 1; num <= n; num++)
{
    int sumDigits = 0;
    int currentNumber = num;
    bool isAllDigitsPrime = true;

    while (currentNumber > 0)
    {
        // взимаме последната цифра от числото
        int lastDigit = currentNumber % 10;

        // Прибавяме я към сумата на всички цифри от текущото число
        sumDigits += lastDigit;

        if (!IsPrime(lastDigit))
        {
            isAllDigitsPrime = false;
            break;
        }

        // Премахваме последната цифра
        currentNumber /= 10;
    }

    // Проверка за числото дали е магическо
    if (isAllDigitsPrime && sumDigits % 2 == 0)
    {
        isFound = true;
        Console.Write(num + " ");
    }
}

if (isFound == false)
{
    Console.WriteLine("no");
}

static bool IsPrime(int number)
{
    if (number <= 1)
        return false;

    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }

    return true;
}
