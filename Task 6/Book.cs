using System;
using System.Collections.Generic;

public class Book
{
	public string Title { get; set; }
	public DateTime? PublicationDate { get; set; }
	public List<Author> Authors { get; set; }
	public string ISBN { get; set; }

	public Book() { }

	public Book(string title, DateTime? publicationDate, IEnumerable<Author> authors, string isbn)
	{
		Title = title;
		PublicationDate = publicationDate;
		Authors = new List<Author>(authors);
		ISBN = isbn;
	}
}
