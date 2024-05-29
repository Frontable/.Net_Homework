using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		
		Catalog catalog = new Catalog();

		
		catalog.AddBook("123-4-56-789012-3", new Book("Book One", new DateTime(2020, 1, 1), new[] { "Author A", "Author B" }));
		catalog.AddBook("1234567890123", new Book("Book Two", new DateTime(2019, 5, 15), new[] { "Author A" }));
		catalog.AddBook("987-6-54-321098-7", new Book("Book Three", null, new[] { "Author C" }));

		
		var sortedTitles = catalog.GetSortedBookTitles();
		Console.WriteLine("Sorted Book Titles:");
		foreach (var title in sortedTitles)
		{
			Console.WriteLine(title);
		}

		
		var booksByAuthorA = catalog.GetBooksByAuthor("Author A");
		Console.WriteLine("\nBooks by Author A:");
		foreach (var book in booksByAuthorA)
		{
			Console.WriteLine(book);
		}

		
		var authorBookCounts = catalog.GetAuthorBookCounts();
		Console.WriteLine("\nAuthor Book Counts:");
		foreach (var (Author, Count) in authorBookCounts)
		{
			Console.WriteLine($"{Author} - {Count} book(s)");
		}

		
		var bookByIsbn = catalog.GetBook("123-4-56-789012-3");
		Console.WriteLine($"\nRetrieved Book by ISBN 123-4-56-789012-3: {bookByIsbn}");

		bookByIsbn = catalog.GetBook("1234567890123");
		Console.WriteLine($"\nRetrieved Book by ISBN 1234567890123: {bookByIsbn}");
	}
}
