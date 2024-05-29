using System.Xml.Serialization;
using System.IO;

public class XmlRepository : IRepository
{
	public void Save(Catalog catalog, string filePath)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
		using (StreamWriter writer = new StreamWriter(filePath))
		{
			serializer.Serialize(writer, catalog);
		}
	}

	public Catalog Load(string filePath)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
		using (StreamReader reader = new StreamReader(filePath))
		{
			return (Catalog)serializer.Deserialize(reader);
		}
	}
}
