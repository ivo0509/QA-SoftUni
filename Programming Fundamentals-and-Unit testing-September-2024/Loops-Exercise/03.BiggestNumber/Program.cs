
int num = int.Parse(Console.ReadLine());

int biggestNumber = int.MinValue;

for (int i = 0; i < num; i++)
{
	int currentNum = int.Parse(Console.ReadLine());

	if (currentNum > biggestNumber)
	{
		biggestNumber = currentNum;
	}
}

Console.WriteLine(biggestNumber);



