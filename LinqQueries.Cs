public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true})!;
        }
    }

    public IEnumerable<Book> GetAllCollection()
    {
        return booksCollection;
    }

    public IEnumerable<Book> BooksAfter2000()
    {
        //Extension method
        //return booksCollection.Where(p=> p.PublishedDate.Year > 2000);

        //Query expresion
        return from l in booksCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> BooksMore250PagesAndActionInTitle()
    {
        return from l in booksCollection where l.PageCount > 250 && l.Title.Contains("Action") select l;
    }

    public bool AllBooksHaveStatus()
    {
        return booksCollection.All(p=> p.Status != string.Empty);
    }

    public bool BooksPublishedIn2005()
    {
        return booksCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> BooksContainingPythonCategory()
    {
        return booksCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> BooksJavaAscending()
    {
        return booksCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> BooksWithMoreThan450PagesAndDescending()
    {
        return booksCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }
} 