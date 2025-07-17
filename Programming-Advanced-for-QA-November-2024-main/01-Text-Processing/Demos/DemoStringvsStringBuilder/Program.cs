/*string text = "";
for (int i = 0; i < 200000; i++)
{
    text += i; //конкатенация върху текстове
}

Console.WriteLine(text);*/

using System.Text;
StringBuilder text = new StringBuilder();
for (int i = 0; i < 200000; i++)
{
    text.Append(i);
}

Console.WriteLine(text);



