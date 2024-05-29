using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Catalog
{
	private Dictionary<string, Book> books;

	public Catalog()
	{
		books = new Dictionary<string, Book>();
	}

	public void AddBook(string isbn, Book book)
	{
		string normalizedIsbn = NormalizeIsbn(isbn);
		if (!books.ContainsKey(normalizedIsbn))
		{
			books[normalizedIsbn] = book;
		}
	}

	public Book GetBook(string isbn)
	{
		string normalizedIsbn = NormalizeIsbn(isbn);
		books.TryGetValue(normalizedIsbn, out Book book);
		return book;
	}

	private string NormalizeIsbn(string isbn)
	{
		return Regex.Replace(isbn, @"[^0-9]", "");
	}

	public IEnumerable<string> GetSortedBookTitles()
	{
		return books.Values.Select(b => b.Title).Distinct().OrderBy(title => title);
	}

	public IEnumerable<Book> GetBooksByAuthor(string author)
	{
		return books.Values
					.Where(b => b.Authors.Contains(author))
					.OrderBy(b => b.PublicationDate);
	}

	public IEnumerable<(string Author, int Count)> GetAuthorBookCounts()
	{
		return books.Values
					.SelectMany(b => b.Authors)
					.GroupBy(author => author)
					.Select(g => (Author: g.Key, Count: g.Count()));
	}
}
