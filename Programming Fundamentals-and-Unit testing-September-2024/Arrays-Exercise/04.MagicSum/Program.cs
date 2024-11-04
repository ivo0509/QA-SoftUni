
int[] numbers = Console.ReadLine()
						  .Split(" ")
						  .Select(int.Parse)
						  .ToArray();

int controlNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < numbers.Length - 1; i++)
{
	int currentElement = numbers[i];

	// ако текущото е по-голямо от контролното
	// няма смисъл за стартираме вътрешния цикъл
	if (currentElement > controlNumber)
		continue;

	for (int j = i + 1; j < numbers.Length; j++)
	{
		int nextRightElement = numbers[j];

		// ако сбора на двете числа е равно на контролното
		// печатаме ги на конзолата и прекъсваме вътрешния цикъл
		if (currentElement + nextRightElement == controlNumber)
		{
			Console.WriteLine(currentElement + " " + nextRightElement);
			break;
		}
    }
}

