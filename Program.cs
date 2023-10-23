LinqQueries queries = new LinqQueries();

// All the collection
//PrintValues(queries.GetAllCollection());

//Books after 2000s
//PrintValues(queries.BooksAfter2000());

//Books with more than 250 pages and action in title
//PrintValues(queries.BooksMore250PagesAndActionInTitle());

// All books have status
//Console.WriteLine(queries.BooksPublishedIn2005());

//Books with python category
//PrintValues(queries.BooksContainingPythonCategory());

//Java Books sorted by asc name
//PrintValues(queries.BooksJavaAscending());

// Books with more than 450 pages in descending order
PrintValues(queries.BooksWithMoreThan450PagesAndDescending());

void PrintValues(IEnumerable<Book> listOfBooks)
{
    Console.WriteLine("{0,-55} {1,9} {2,11}\n", "Title", "N. Pages", "Date published");
    foreach(var item in listOfBooks)
    {
        System.Console.WriteLine("{0,-55} {1,9} {2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
