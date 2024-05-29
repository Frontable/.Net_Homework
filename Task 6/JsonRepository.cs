using Newtonsoft.Json;
using System.IO;

public class JsonRepository : IRepository
{
	public void Save(Catalog catalog, string directoryPath)
	{
		catalog.SaveToJson(directoryPath);
	}

	public Catalog Load(string directoryPath)
	{
		var catalog = new Catalog();
		catalog.LoadFromJson(directoryPath);
		return catalog;
	}
}
