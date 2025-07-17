//Throw Exceptions -> ръчно да "хвърлим" определен вид грешка, която да прекрати програмата

string text = "desislavaasadasda";
if (text.Length <= 0 || text.Length >= 10)
{
    //невалиден текст -> не искам програмата ми да продължава
    throw new ArgumentException("You text has to be between 0 and 10 symbols exclusive");
}

Console.WriteLine("Hello");

