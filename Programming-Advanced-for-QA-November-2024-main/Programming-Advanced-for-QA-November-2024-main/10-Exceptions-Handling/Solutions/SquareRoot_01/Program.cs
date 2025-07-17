try
{

    int number = int.Parse(Console.ReadLine());

    if (number < 0)
    {
        throw new ArgumentException("Invalid number."); //ръчно си "хвърляме" грешка
    }
    else
    {
        //number >= 0
        Console.WriteLine(Math.Sqrt(number));
    }
}
catch (ArgumentException argEx)
{
    Console.WriteLine(argEx.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}

