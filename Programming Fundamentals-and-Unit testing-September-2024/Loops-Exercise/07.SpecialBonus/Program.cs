int stopNumber = int.Parse(Console.ReadLine());

int currentNum = int.Parse(Console.ReadLine());

int previousNum = 0;

while (currentNum != stopNumber)
{
	previousNum = currentNum;

	currentNum = int.Parse(Console.ReadLine());
}

Console.WriteLine(previousNum * 1.2);