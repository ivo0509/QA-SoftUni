// създаваме обект от тип Dog без данни в пропъртитата.
Dog firstDog = new Dog();
// подаваме данни в пропъртитата след като вече имаме обекта от тип Dog
firstDog.Name = "Doncho";
firstDog.Breed = "Shepard";
firstDog.Age = 3;

// създаваме обект от тип Dog като му подаваме данните през конструктора
Dog secondDog = new Dog("Kircho", "Corgi", 5);

Console.WriteLine($"First dog name is: {firstDog.Name}");
Console.WriteLine($"Second dog name is: {secondDog.Name}");

// създаваме си колекция, която ще пази обекти от нашия тип Dog
List<Dog> dogs = new List<Dog>();
dogs.Add(firstDog);
dogs.Add(secondDog);

// вградени статични класове в C#
// можем да ползваме методите на тези класове без инстанция на класа 
double cosinus = Math.Cos(Math.PI);
Console.WriteLine(cosinus);

// на вградените нестатични класове, първо трябва да вдигнем инстанция на класа
// за да можем да извикаме методите на класа през текущата инстанцията
Random random = new Random();
Console.WriteLine(random.Next(1, 100));

class Dog 
{
    // празен конструктор
    public Dog() { }
    //конструктор който задължително очаква данните при нова инстанция на класа
    public Dog(string name, string breed, int age) 
    { 
        Name = name;
        Breed = breed;
        Age = age;
    }

    // пропъртита (характеристики на класа)
    public string Name { get; set; }

    public string Breed { get; set; }

    public int Age { get; set; }

    // методи (поведение на класа)
    public string Bark()
    {
        return "Woof woof";
    }

    public string Eat()
    {
        return "Yam yam";
    }
}
