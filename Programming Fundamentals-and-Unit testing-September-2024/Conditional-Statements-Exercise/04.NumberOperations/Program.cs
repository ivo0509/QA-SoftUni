
double firstNumber = double.Parse(Console.ReadLine());
double secondNumber = double.Parse(Console.ReadLine());
string mathOperator = Console.ReadLine();

double result = 0;

switch (mathOperator)
{
	case "+": result = firstNumber + secondNumber; break;
	case "-": result = firstNumber - secondNumber; break;
	case "*": result = firstNumber * secondNumber; break;
	case "/": result = firstNumber / secondNumber; break;
}	

Console.WriteLine($"{firstNumber} {mathOperator} {secondNumber} = {result:F2}");
