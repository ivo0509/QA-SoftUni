//Exception -> грешка, която се появява по време на изпълнение на нашата програма
//             и я прекратява на реда, в който сме получили грешката
//1. message: текст, който е прикрепен към грешката, за да може да обясни по-подробно какъв е проблемът
//2. stack trace: съвкупност от редове, които ни показват от къде е първоичточника на дадена грешка

//Exception Hierarchy -> всеки exception може да бъде заменен с някой над него в йерархията

//int num = int.Parse("gft45"); //FormatException




//Handling Exceptions -> обработка на грешки, за да не ми прекратяват директно програмата
try
{
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine(5 / number); //DivideByZeroException
    Console.WriteLine("Test");

    int[] array = new int[2];
    array[0] = 5;
    array[1] = 6;

    Console.WriteLine(array[2]); //IndexOutOfBoundsException
}
catch (Exce ex)
{
    //какво искаме да се случи ако получим DivideByZeroException
    Console.WriteLine("You cannot divide by zero. Please, fix it.");
    Console.WriteLine(ex.Message);
}
catch (IndexOutOfRangeException e)
{
    //какво искаме да се случи ако получим IndexOutOfRangeException
    Console.WriteLine("Given index is out of range of the array.");
    Console.WriteLine(e.Message);
}
finally
{
    //код, който се изпълнява винаги
    Console.WriteLine("End.");
}


//Multiple exceptions catching
try
{
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine(5 / number); //DivideByZeroException
    Console.WriteLine("Test");

    int[] array = new int[2];
    array[0] = 5;
    array[1] = 6;

    Console.WriteLine(array[2]); //IndexOutOfBoundsException
}
catch (Exception ex)
{
    if (ex.GetType().ToString() == "DivideByZeroException")
    {
        Console.WriteLine("You cannot divide by zero.");
    }
    else if (ex.GetType().ToString() == "IndexOutOfBoundsException")
    {
        Console.WriteLine("Index os out of array.");
    }
}
finally
{
    //код, който се изпълнява винаги
    Console.WriteLine("End.");
}

