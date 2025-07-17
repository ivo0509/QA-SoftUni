
List<Student> students = new List<Student>();
string input = Console.ReadLine();

while (input != "end")
{
    string[] cmdArg = input.Split(' ');

    string firstName = cmdArg[0];
    string lastName = cmdArg[1];
    int age = int.Parse(cmdArg[2]);
    string homeTown = cmdArg[3];

    Student student = new Student(firstName, lastName, age, homeTown);

    students.Add(student);

    input = Console.ReadLine();
}

string cityName = Console.ReadLine()!;

foreach (Student student in students.Where(s => s.HomeTown == cityName))
{
    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");  
}

class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

   

