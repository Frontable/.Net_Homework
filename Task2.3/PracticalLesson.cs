using System;

class PracticalLesson : Lesson
{
	public string TaskLink { get; }
	public string SolutionLink { get; }

	public PracticalLesson(string description, string taskLink, string solutionLink) : base(description)
	{
		TaskLink = taskLink;
		SolutionLink = solutionLink;
	}
}
