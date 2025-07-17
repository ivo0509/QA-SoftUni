//Program.cs -> съхраняваме програмна логика (входни данни, изходни данни, изчисления)

string articleData = Console.ReadLine();
//articleData = "Fight club, love story, Martin Scorsese"

string[] dataParts = articleData.Split(", ");
//articleData.Split(", ") -> dataParts = ["Fight club", "love story", "Martin Scorsese"]

string title = dataParts[0];    //заглавие на въведената статия
string content = dataParts[1];  //съдържание на въведената статия
string author = dataParts[2];   //автор на въведената статия

//създаваме статия по въведените данни
Article article = new Article(title, content, author);


int countCommands = int.Parse(Console.ReadLine()); //брой команди

for (int count = 1; count <= countCommands; count++)
{
    string command = Console.ReadLine(); //команда, която трябва да изпълня върху статията

    //1. command = "Edit: scary story".split(": ")         -> commandParts = ["Edit", "scary story"]
    //2. command = "ChangeAuthor: Ivan Ivanov".split(": ") -> commandParts = ["ChangeAuthor", "Ivan Ivanov"]
    //3. command = "Rename: Test Title".split(": ")        -> commandParts = ["Rename", "Test Title"]

    string[] commandParts = command.Split(": ");
    string commandName = commandParts[0]; //име на команда -> "Edit", "ChangeAuthor", "Rename"
    string commandParameter = commandParts[1];

    switch (commandName)
    {
        case "Edit":
            //промяна на съдържанието на създадената статия
            article.Edit(commandParameter);
            break;
        case "ChangeAuthor":
            //промяна на автора на създадената статия
            article.ChangeAuthor(commandParameter);
            break;
        case "Rename":
            //промяна на заглавието на създадената статия
            article.Rename(commandParameter);
            break;
    }

}

//изпълнили сме всички въведени команди -> принтираме статия
//"{title} - {content}: {author}"

//начин 1
//Console.WriteLine(article.Title + " - " + article.Content + ": " + article.Author);

//начин 2
//Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

//начин 3
Console.WriteLine(article.ToString());







