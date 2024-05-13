class Session { }

class Lecture : Session
{
	public string Topic { get; }

	public Lecture(string topic)
	{
		Topic = topic;
	}
}