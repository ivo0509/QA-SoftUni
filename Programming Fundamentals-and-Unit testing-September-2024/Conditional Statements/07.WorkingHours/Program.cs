
int hour = int.Parse(Console.ReadLine());
string dayOfWeek = Console.ReadLine();

if (hour >= 10 && hour <= 18 && (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday" || dayOfWeek == "Saturday"))
{
	Console.WriteLine("open");
}
else
{
    Console.WriteLine("closed");
}

// по-краткото решение
//
//if (dayOfWeek == "Sunday" || hour < 10 || hour > 18)
//{
//    Console.WriteLine("closed");
//}	
//else
//{
//    Console.WriteLine("open");
//}
