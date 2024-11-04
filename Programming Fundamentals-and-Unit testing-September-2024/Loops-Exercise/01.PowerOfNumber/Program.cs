
int num = int.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());

int result = 1;

for (int i = 0; i < power; i++)
{
	result *= num;
}

Console.WriteLine(result);
