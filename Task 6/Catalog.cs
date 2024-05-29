using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

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
			Console.WriteLine($"Added book: {book.Title} with ISBN: {isbn}");
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
		return new string(isbn.Where(char.IsDigit).ToArray());
	}

	public IEnumerable<string> GetSortedBookTitles()
	{
		return books.Values.Select(b => b.Title).Distinct().OrderBy(title => title);
	}

	public IEnumerable<Book> GetBooksByAuthor(string author)
	{
		return books.Values
					.Where(b => b.Authors.Any(a => $"{a.FirstName} {a.LastName}" == author))
					.OrderBy(b => b.PublicationDate);
	}

	public IEnumerable<(string Author, int Count)> GetAuthorBookCounts()
	{
		return books.Values
					.SelectMany(b => b.Authors)
					.GroupBy(author => $"{author.FirstName} {author.LastName}")
					.Select(g => (Author: g.Key, Count: g.Count()));
	}

	public void SaveToXml(string filePath)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
		using (StreamWriter writer = new StreamWriter(filePath))
		{
			serializer.Serialize(writer, books.Values.ToList());
			Console.WriteLine($"Catalog saved to XML: {filePath}");
			foreach (var book in books.Values)
			{
				Console.WriteLine($"Saved book: {book.Title} with ISBN: {book.ISBN}");
			}
		}
	}

	public void LoadFromXml(string filePath)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
		using (StreamReader reader = new StreamReader(filePath))
		{
			var bookList = (List<Book>)serializer.Deserialize(reader);
			foreach (var book in bookList)
			{
				AddBook(book.ISBN, book);
			}
			Console.WriteLine($"Catalog loaded from XML: {filePath}");
			Console.WriteLine($"Loaded {bookList.Count} books from XML.");
		}
	}

	public void SaveToJson(string directoryPath)
	{
		var authorGroups = books.Values
								.SelectMany(book => book.Authors.Select(author => new { Author = author, Book = book }))
								.GroupBy(x => x.Author);

		foreach (var group in authorGroups)
		{
			string authorFileName = $"{group.Key.FirstName}_{group.Key.LastName}.json";
			string filePath = Path.Combine(directoryPath, authorFileName);

			var booksByAuthor = group.Select(x => x.Book).ToList();

			string json = JsonConvert.SerializeObject(booksByAuthor, Formatting.Indented);
			File.WriteAllText(filePath, json);
			Console.WriteLine($"Catalog saved to JSON for author: {group.Key.FirstName} {group.Key.LastName}");
			foreach (var book in booksByAuthor)
			{
				Console.WriteLine($"Saved book: {book.Title} with ISBN: {book.ISBN}");
			}
		}
	}

	public void LoadFromJson(string directoryPath)
	{
		var files = Directory.GetFiles(directoryPath, "*.json");
		var bookList = new List<Book>();

		foreach (var file in files)
		{
			string json = File.ReadAllText(file);
			var books = JsonConvert.DeserializeObject<List<Book>>(json);
			foreach (var book in books)
			{
				AddBook(book.ISBN, book);
			}
			Console.WriteLine($"Catalog loaded from JSON file: {file}");
		}
		Console.WriteLine($"Loaded {books.Count} books from JSON.");
	}
}
