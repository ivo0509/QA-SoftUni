
int num = int.Parse(Console.ReadLine());

int temp = num;
bool isSpecial = true;

while (temp > 0)
{
	// вземаме последната цифра от числото
	int lastDigit = temp % 10;

	// премахваме последната цифра от числото
	temp = temp / 10; 

	// ако текущото деление има остатък, прекъсваме цикъла
	// няма смисъл да делим на другите цифри от числото
	if (num % lastDigit != 0)
	{
		isSpecial = false;
		break;
	}
}

if (isSpecial)
{
    Console.WriteLine($"{num} is special");
}
else
{
    Console.WriteLine($"{num} is not special");
}

