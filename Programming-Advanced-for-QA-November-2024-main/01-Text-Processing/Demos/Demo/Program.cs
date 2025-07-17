//ТЕКСТЪТ Е СЪВКУПНОСТ ОТ СИМВОЛИ
string name = "Desislava";

//дължина на текст = броя на символи
Console.WriteLine(name.Length);
int length = name.Length;

//достъп на символите в текста
//първия символ в текста
char firstSymbol = name[0];
Console.WriteLine(name[0]);

//последния символ в текста
Console.WriteLine(name[name.Length - 1]);

//работа със символи
char letter = 'A';
char symbol = char.Parse(Console.ReadLine());

//string = array of chars
char[] array = name.ToCharArray();
//"Desislava" -> ['D', 'e', 's', 'i', 's', 'l', 'a', 'v', 'a']
foreach (char s in array)
{
    Console.WriteLine(s);
}


//IMMUTABLE = READ-ONLY
//при промяна на текста трябва да го презапишем в променливата
Console.WriteLine(name[2]);
name = name.Remove(4);

//обхождане на символите в текста
//1. foreach -> трябва да обходим всички символи без значение от тяхната позиция
foreach (char sym in name)
{
    //какво действие искаме да повторим за всеки символ
    Console.WriteLine(sym);
}

//2. for -> трябва да обходим всички символи и да работим с позициите
for (int position = 0; position <= name.Length - 1; position++)
{
    if (position % 2 == 0)
    {
        Console.WriteLine(name[position]);
    }   
}

//конкатенация = долепване на текстове
string firstName = "Desislava";
string lastName = "Topuzakova";
int age = 26;
double grade = 5.90;
char smallLetter = 'O';

//конкатенация с оператор +
string sentence = "I am " + firstName + " " + lastName + " and I am " + age + " years old.";
Console.WriteLine(firstName + lastName);    //string + string = string
Console.WriteLine(firstName + age);         //string + int = string
Console.WriteLine(lastName + grade);        //string + double = string
Console.WriteLine(firstName + smallLetter); //string + char = string

//конкатенация с Concat
string greeting = string.Concat("I am ", firstName, " ", lastName, " and I am ", age, " years old.");

//Join
string fullName = string.Join(" ", firstName, lastName);

string[] names = new string[3] { "Desi", "Ivan", "Peter" };
Console.WriteLine(string.Join(" : ", names));

//IndexOf -> позицията, на която за първи път срещаме думата
string fruits = "banana, apple, kiwi, banana, apple";
Console.WriteLine(fruits.IndexOf("banana")); // 0
Console.WriteLine(fruits.IndexOf("kiwi")); //15
Console.WriteLine(fruits.IndexOf("orange")); // -1 -> нямаме такъв текст

//LastIndexOf -> позицията, на която за последен път срещаме думата
Console.WriteLine(fruits.LastIndexOf("banana")); // 21
Console.WriteLine(fruits.LastIndexOf("orange")); // -1 -> нямаме такъв текст


//Contains -> проверява дали даден текст се съдържа в друг текст
string animal = "Elephant";
bool isContains = animal.Contains("il"); //false
Console.WriteLine(animal.Contains("nt")); //true
Console.WriteLine(animal.Contains("test")); //false

if (animal.Contains("test"))
{
    Console.WriteLine("Test is completed");
}

//Substring - да взима подтекст от друг текст

//Substring (startPosition)
string player = "Ivan Ivanov";
Console.WriteLine(player.Substring(5)); //"Ivanov"

//Substring (startPosition, length)
Console.WriteLine(player.Substring(0, 4)); //"Ivan"


//Remove - премахва елементи от текста

//Remove (startPosition)
string hero = "Iron Man";
hero = hero.Remove(5); //премахва всички символи от този на 5-та позиция до края

//Remove (startPosition, length)
hero = hero.Remove(0, 5);


//Split

//1. Split по един разделител
string text = "Hello, john@softuni.org, you have been using john@softuni.org in your registration";
string[] words = text.Split(", ");
//["Hello,", "john@softuni.org,", "you", "have", "been", "using", "john@softuni.org", "in", "your", "registration"]


//2. Split по повече от един разделител
char[] separators = new char[] { ' ', ',', '.' };
string randomText = "Hello, I am John.";

string[] parts = randomText.Split(separators);
// ["Hello", "I", "am", "John"]


//Replace -> заменя дадена дума в текст с друга дума
string title = "I am Ivan Ivanov from from from from.";
title = title.Replace("from", "Sofia");
//title = "I am Ivan Ivanov Sofia Sofia Sofia Sofia.";


//Trim -> премахва празните места в началото и края на текста
string content = "    Peter is great.    ";
content = content.Trim(); //"Peter is great."

//TrimEnd -> премахва празните места в края на текста
//TrimStart -> премахва празните места в началото на текста


