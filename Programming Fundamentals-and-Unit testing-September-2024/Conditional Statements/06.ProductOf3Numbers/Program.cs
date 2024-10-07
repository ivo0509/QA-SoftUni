
double firstNumber = double.Parse(Console.ReadLine());
double secondNumber = double.Parse(Console.ReadLine());
double thirdNumber = double.Parse(Console.ReadLine());

if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
{
    Console.WriteLine("zero");
}
else if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0)
{
    Console.WriteLine("negative");
}
else if (firstNumber > 0 && secondNumber > 0 && thirdNumber < 0)
{
	Console.WriteLine("negative");
}
else if (firstNumber > 0 && secondNumber < 0 && thirdNumber > 0)
{
	Console.WriteLine("negative");
}
else if (firstNumber < 0 && secondNumber > 0 && thirdNumber > 0)
{
	Console.WriteLine("negative");
}
else
{
    Console.WriteLine("positive");
}