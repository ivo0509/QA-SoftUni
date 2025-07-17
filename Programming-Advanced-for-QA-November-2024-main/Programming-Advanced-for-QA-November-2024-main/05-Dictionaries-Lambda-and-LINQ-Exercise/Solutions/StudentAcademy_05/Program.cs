//име на студент -> списък с оценки
Dictionary<string, List<double>> studentsGrade = new Dictionary<string, List<double>>();

//входни данни
int countStudents = int.Parse(Console.ReadLine()); //брой на студентите

for (int student = 1; student <= countStudents; student++)
{
    string studentName = Console.ReadLine(); //име на студента
    double grade = double.Parse(Console.ReadLine()); // получена оценка

    //срещали сме го вече този студент
    if (studentsGrade.ContainsKey(studentName))
    {
        studentsGrade[studentName].Add(grade);
    }
    //не сме го срещали този студент
    else
    {
        studentsGrade.Add(studentName, new List<double>() { grade });
    }

}

//studentsGrade: key (име на студента) -> value (списък с оценки)
foreach(KeyValuePair<string, List<double>> entry in studentsGrade)
{
    //всеки един запис се съхранява в entry
    //entry.Key -> име на студента
    //entry.Value -> списък с оценки

    string studentName = entry.Key;
    double averageGrade = entry.Value.Average();

    if (averageGrade >= 4.50)
    {
        Console.WriteLine($"{studentName} -> {averageGrade:F2}");
    }
}

