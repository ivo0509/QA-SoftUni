//Program.cs -> съхраняваме програмна логика (входни данни, изходни данни, изчисления)
int countStudents = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();
for (int studentCount = 1; studentCount <= countStudents; studentCount++)
{
    string data = Console.ReadLine(); //данни за студента
    //data = "Desislava Topuzakova 4.50"
    //data.Split()
    //dataParts = ["Desislava", "Topuzakova", "4.50"]
    string[] dataParts = data.Split(); //data.Split(" ")

    string firstName = dataParts[0]; //"Desislava"
    string lastName = dataParts[1]; //"Topuzakova"
    double grade = double.Parse(dataParts[2]); //"4.50" -> 4.50

    Student student = new Student(firstName, lastName, grade);
    students.Add(student);

}

//списък с обекти от клас Student
//1. сортирам по оценка в descending order (намаляващ ред)
students = students.OrderByDescending(s => s.Grade).ToList();

//2. отпечатвам информация за всеки студент
foreach(Student student in students)
{
    Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
}



