
int firstTime = int.Parse(Console.ReadLine());
int secondTime = int.Parse(Console.ReadLine());
int thirdTime = int.Parse(Console.ReadLine());

int timeInSecond = firstTime + secondTime + thirdTime; 

int minutes = timeInSecond / 60;
int seconds = timeInSecond % 60;

if (seconds < 10)
{
	Console.WriteLine($"{minutes}:0{seconds}");
}
else
{
	Console.WriteLine($"{minutes}:{seconds}");
}

// по-кратко решение
//Console.WriteLine($"{minutes}:{seconds:D2}");





