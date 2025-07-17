public class Person
{
    //характеристики
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    //конструктор
    public Person(string name, int age, string town)
    {
        //нов празен обект
        Name = name;
        Age = age;
        Town = town;
    }

    //default methods -> ToString() -> "име на класа"
    //пренапиша метода, за да работи както аз искам
    public override string ToString()
    {
        return $"{Name}: {Age} from {Town}";
    }
}

