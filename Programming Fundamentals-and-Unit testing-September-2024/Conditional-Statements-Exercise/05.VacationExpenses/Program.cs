
string season = Console.ReadLine();             //"Spring", "Summer", "Autumn" and "Winter"
string accommodationType = Console.ReadLine();  //"Hotel" or "Camping"
int countOfDays = int.Parse(Console.ReadLine());

int pricePerDay = 0;
double discount = 0;

if (accommodationType == "Hotel")
{
    switch (season)
    {
        case "Spring":
			pricePerDay = 30;
			discount = 20;

			//по-описателния вариант
			//double price = pricePerDay * countOfDays;
			//double finalPriceForVacation = price - (price * discount / 100);
			//Console.WriteLine($"{finalPriceForVacation:F2}");
			break;
		case "Summer":
			pricePerDay = 50;
			break;
		case "Autumn":
			pricePerDay = 20;
			discount = 30;
			break;
		case "Winter":
			pricePerDay = 40;
			discount = 10;
			break;
	}
}
else if (accommodationType == "Camping")
{
	switch (season)
	{
		case "Spring":
			pricePerDay = 10;
			discount = 20;
			break;
		case "Summer":
			pricePerDay = 30;
			break;
		case "Autumn":
			pricePerDay = 15;
			discount = 30;
			break;
		case "Winter":
			pricePerDay = 10;
			discount = 10;
			break;
	}
}

double finalPrice = pricePerDay * countOfDays * (1 - (discount / 100));
Console.WriteLine($"{finalPrice:F2}");
