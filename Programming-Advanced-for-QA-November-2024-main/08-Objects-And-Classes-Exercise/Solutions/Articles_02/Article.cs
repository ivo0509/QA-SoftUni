public class Article
{
    //характеристики: заглавие, съдържание, автор -> описват в property
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    //конструктор: метод, чрез който си създаваме обект от класа
    public Article(string title, string content, string author)
    {
        //нов празен обект
        Title = title;
        Content = content;
        Author = author;
    }

    //действия -> описват чрез методи

    public void Edit (string newContent)
    {
        //променя съдържанието на моята статия
        Content = newContent;
    }

    public void ChangeAuthor (string newAuthor)
    {
        //променя автора на моята статия
        Author = newAuthor;
    }

    public void Rename (string newTitle)
    {
        //променя заглавието на моята статияс
        Title = newTitle;
    }

    //default methods -> ToString() -> "име на класа"
    //искам да пренапиша метода ToString() -> "{заглавие} - {съдържание}: {автор}"
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

