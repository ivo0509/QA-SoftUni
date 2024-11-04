
int[] numbersArray = Console.ReadLine()
						  .Split(" ")
						  .Select(int.Parse)
						  .ToArray();

int rotations = int.Parse(Console.ReadLine());

// оптимизация на ротациите
if (rotations > numbersArray.Length)
	rotations = rotations % numbersArray.Length;

// оптимизация, ако ротациите са равни на дължината на масива
// няма смисъл да се изпълнява логиката
if (rotations != numbersArray.Length)
{
	for (int i = 0; i < rotations; i++)
	{
		int firstElement = numbersArray[0];

		for (int j = 1; j < numbersArray.Length; j++)
		{
			numbersArray[j - 1] = numbersArray[j];
		}

		numbersArray[numbersArray.Length - 1] = firstElement;
	}
}

Console.WriteLine(string.Join(" ", numbersArray));