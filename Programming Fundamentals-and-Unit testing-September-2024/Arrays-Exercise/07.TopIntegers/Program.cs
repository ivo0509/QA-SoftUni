
int[] numbersArray = Console.ReadLine()
						  .Split(" ")
						  .Select(int.Parse)
						  .ToArray();


for (int i = 0; i < numbersArray.Length - 1; i++)  
{
	// bool променлива, да пазим състояния дали
	// всички числа надясно са по-малки
	bool isGreater = true;

	// вземаме текущото число
	int currentElement = numbersArray[i]; 

	// обикаляме всички елементи след текущия
	for (int j = i + 1; j < numbersArray.Length; j++)
	{
		// вземаме всеки следващ елемент до края на масива
		int nextRightElement = numbersArray[j]; 

		// ако някой от следващите е по-голям, не печатаме текущия елемент
		if (nextRightElement >= currentElement)
		{
			isGreater = false;
			break;
		}
	}

	if (isGreater)
	{
        Console.Write(currentElement + " ");
    }
}

Console.Write(numbersArray[numbersArray.Length - 1]);
