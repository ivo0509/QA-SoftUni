
string input = Console.ReadLine();

double accountBalance = 0;

while (input != "End")
{
	double currentAmount = double.Parse(input);

	if (currentAmount > 0)
	{
		accountBalance += currentAmount;
        Console.WriteLine($"Increase: {currentAmount:F2}");
    }
	else if (currentAmount < 0)
	{
		accountBalance -= Math.Abs(currentAmount);
        Console.WriteLine($"Decrease: {Math.Abs(currentAmount):F2}");
    }

	input = Console.ReadLine();
}

Console.WriteLine($"Balance: {accountBalance:F2}");
