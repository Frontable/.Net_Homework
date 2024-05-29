using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
	public static void Main()
	{
		Catalog catalog = new Catalog();

		var author1 = new Author("John", "Doe", new DateTime(1980, 1, 1));
		var author2 = new Author("Jane", "Smith", new DateTime(1975, 5, 20));
		var author3 = new Author("Emily", "Johnson", new DateTime(1990, 3, 15));

		catalog.AddBook("123-4-56-789012-3", new Book("Book One", new DateTime(2020, 1, 1), new[] { author1, author2 }, "123-4-56-789012-3"));
		catalog.AddBook("1234567890123", new Book("Book Two", new DateTime(2018, 5, 10), new[] { author1 }, "1234567890123"));
		catalog.AddBook("987-6-54-321098-7", new Book("Book Three", new DateTime(2019, 10, 25), new[] { author2 }, "987-6-54-321098-7"));
		catalog.AddBook("9876543210987", new Book("Book Four", new DateTime(2021, 7, 15), new[] { author3 }, "9876543210987"));

		string xmlPath = "catalog.xml";
		string jsonDirectory = "json_catalog";

		
		if (!Directory.Exists(jsonDirectory))
		{
			Directory.CreateDirectory(jsonDirectory);
		}

		// Save to XML
		IRepository xmlRepository = new XmlRepository();
		xmlRepository.Save(catalog, xmlPath);

		// Load from XML
		Catalog catalogFromXml = xmlRepository.Load(xmlPath);

		// Save to JSON
		IRepository jsonRepository = new JsonRepository();
		jsonRepository.Save(catalog, jsonDirectory);

		// Load from JSON
		Catalog catalogFromJson = jsonRepository.Load(jsonDirectory);

		
		Console.WriteLine("Catalog loaded from XML:");
		foreach (var title in catalogFromXml.GetSortedBookTitles())
		{
			Console.WriteLine(title);
		}

		Console.WriteLine("\nCatalog loaded from JSON:");
		foreach (var title in catalogFromJson.GetSortedBookTitles())
		{
			Console.WriteLine(title);
		}
	}
}
