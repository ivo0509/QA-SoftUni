using System.Text;

//StringBuilder -> пространство, което използваме, за да може да конструираме текст в него
StringBuilder sb = new StringBuilder(); //""

//добавяне на текст
sb.Append("Desislava ").Append(" Topuzakova").Append(" is 26 years old.");

Console.WriteLine(sb.ToString()); //отпечатваме текста, който се е конструрал в sb
string text = sb.ToString(); //връща конструирания текст в sb

//дължинa на текста конструиран в sb
Console.WriteLine(sb.Length);

sb.Clear(); //изпразва sb и го оставя с празен текст в него -> sb = ""

//достъпване на символ в текста на sb
Console.WriteLine(sb[0]);

//вмъкване на текст
sb.Insert(0, "Ivan Ivanov");

//замяна на текст
sb.Replace("Ivan", "Peter");

//премахване на текст
sb.Remove(0, 5);