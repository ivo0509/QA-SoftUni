//1. входни данни -> масив от текстове

string[] words = Console.ReadLine().Split(" ");
//"hi abc add".Split(" ") -> ["hi", "abc", "add"]

string result = ""; //краен текст

//2. обхождаме всеки един текст в масива
foreach (string word in words)
{
    //word = "add"
    //дължина = 3

    int length = word.Length;

    //повтаряме: добавяме думата към крайния текст
    //брой повторения = дължина на дума
    for (int count = 1; count <= length; count++)
    {
        result += word;
    }
}

//3. отпечатваме крайния текст
Console.WriteLine(result);
