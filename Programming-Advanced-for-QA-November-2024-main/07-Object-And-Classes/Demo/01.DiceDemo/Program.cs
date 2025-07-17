
namespace DiceDemo
{
    // ползваме този using, защото класа Dice се намита в друг namespace
    using DiceNamespace; 

    class Program
    {
        public static void Main()
        {
            Dice dice1 = new Dice(12);

            Dice dice2 = new Dice();
        }
    }
}

namespace DiceNamespace
{
    class Dice
    {
        public Dice()
        {
            // при празен конструктор слагаме начална стойност 6
            Sides = 6; 
        }

        public Dice(int countOfSides)
        {
            Sides = countOfSides;
            Color = "White";
        }

        public int Sides { get; set; }

        public string Color { get; set; }

        public void Roll()
        {
            Random randomInteger = new Random();
            Console.WriteLine(randomInteger.Next(1, Sides + 1));
        }
    }
}

