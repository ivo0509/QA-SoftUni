
int num = int.Parse(Console.ReadLine());

int countDivideBy2 = 0;
int countDivideBy3 = 0;
int countDivideBy4 = 0;

for (int i = 0; i < num; i++)
{
	int currentNum = int.Parse(Console.ReadLine());

	if (currentNum % 2 == 0)
	{
		countDivideBy2++;
	}

	if (currentNum % 3 == 0) 
	{ 
		countDivideBy3++; 
	}

	if (currentNum % 4 == 0)
	{
		countDivideBy4++;
	}
}

// Кастваме към (double), за да избегнем целочислено деление
double percentDivideBy2 = (double)countDivideBy2 / num * 100 ;
double percentDivideBy3 = (double)countDivideBy3 / num * 100;
double percentDivideBy4 = (double)countDivideBy4 / num * 100;

Console.WriteLine($"{percentDivideBy2:F2}%");
Console.WriteLine($"{percentDivideBy3:F2}%");
Console.WriteLine($"{percentDivideBy4:F2}%");
