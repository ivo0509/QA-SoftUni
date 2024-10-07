
int number = int.Parse(Console.ReadLine());

if (number > 0)
{
    Console.WriteLine("positive");
}
else if (number < 0)
{
    Console.WriteLine("negative");
}
else
{
    Console.WriteLine("zero");
}

//switch (number)
//{
//	case > 0:
//		Console.WriteLine("positive");
//		break;
//	case < 0:
//		Console.WriteLine("negative");
//		break;
//	default:
//		Console.WriteLine("zero");
//		break;
//}