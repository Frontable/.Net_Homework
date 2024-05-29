using System;
using System.Collections.Generic;

public class Book
{
	public string Title { get; private set; }
	public DateTime? PublicationDate { get; private set; }
	public HashSet<string> Authors { get; private set; }

	public Book(string title, DateTime? publicationDate, IEnumerable<string> authors)
	{
		if (string.IsNullOrWhiteSpace(title))
		{
			throw new ArgumentException("Title cannot be null or empty.", nameof(title));
		}

		Title = title;
		PublicationDate = publicationDate;
		Authors = new HashSet<string>(authors ?? new List<string>());
	}

	public override string ToString()
	{
		return $"{Title} ({PublicationDate?.ToString("yyyy-MM-dd") ?? "No Date"}) by {string.Join(", ", Authors)}";
	}
}
