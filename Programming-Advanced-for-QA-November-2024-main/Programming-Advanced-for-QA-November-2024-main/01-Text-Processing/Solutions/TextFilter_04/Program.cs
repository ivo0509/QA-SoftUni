//1. входни данни

string[] badWords = Console.ReadLine().Split(", ");
//"Linux, Windows".Split(", ") -> ["Linux", "Windows"]

string text = Console.ReadLine();
//text = "It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the
//        functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely,
//        a Windows client"


//2. обхождаме и заместваме всички забранени думи
foreach (string badWord in badWords)
{
    //badWord = "Windows"
    //replacement = "*******";

    string replacement = new string('*', badWord.Length);
    text = text.Replace(badWord, replacement);
}

//3. отпечатваме финалния текст
Console.WriteLine(text);


