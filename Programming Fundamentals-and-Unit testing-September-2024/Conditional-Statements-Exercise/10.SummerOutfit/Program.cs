
int degrees = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();

string outfit = "";
string shoes = "";

//"Morning", "Afternoon", "Evening"
switch (timeOfDay)
{
	case "Morning":
		if (degrees >=10 && degrees <= 18)
		{
			outfit = "Sweatshirt";
			shoes = "Sneakers";
		}
		else if (degrees > 18 && degrees <= 24)
		{
			outfit = "Shirt";
			shoes = "Moccasins";
		}
		else if (degrees > 24)
		{
			outfit = "T-Shirt";
			shoes = "Sandals";
		}
		break;
	case "Afternoon":
		switch (degrees)
		{
			case >= 10 and <= 18:
				outfit = "Shirt";
				shoes = "Moccasins";
				break;
			case > 18 and <= 24:
				outfit = "T-Shirt";
				shoes = "Sandals";
				break;
			case > 24:
				outfit = "Swim Suit";
				shoes = "Barefoot";
				break;
		}
		break;
	case "Evening":
		outfit = "Shirt";
		shoes = "Moccasins";
		break;
}

Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");