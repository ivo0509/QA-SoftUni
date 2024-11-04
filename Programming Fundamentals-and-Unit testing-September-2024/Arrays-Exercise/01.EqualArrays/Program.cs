
int[] firstArray = Console.ReadLine()
						  .Split(" ")
						  .Select(int.Parse)
						  .ToArray();

int[] secondArray = Console.ReadLine()
						  .Split(" ")
						  .Select(int.Parse)
						  .ToArray();

bool areEqual = true;

for (int i = 0; i < firstArray.Length; i++)
{
	if (firstArray[i] != secondArray[i])
	{
		areEqual = false;
		break;
	}
}

if (areEqual)
{
    Console.WriteLine("Arrays are identical.");
}
else
{
    Console.WriteLine("Arrays are not identical.");
}

