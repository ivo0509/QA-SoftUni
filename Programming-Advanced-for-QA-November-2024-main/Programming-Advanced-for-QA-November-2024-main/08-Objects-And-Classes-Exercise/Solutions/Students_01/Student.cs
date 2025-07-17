public class Student
{
    //характеристики: име, фамилия, оценка
    //properties -> описваме характеристиките и осигуряваме достъп до тези характеристики
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }

    //constructor -> специален метод, който се казва по същия начин, по който се казва и класът
    //            -> създава обекти от клас
    public Student (string firstName, string lastName, double grade)
    {
        //нов празен обект
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

}

