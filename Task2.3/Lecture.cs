using System;

class Lecture : Lesson
{
	public string Topic { get; }

	public Lecture(string description, string topic) : base(description)
	{
		Topic = topic;
	}
}
