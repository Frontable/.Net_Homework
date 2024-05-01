using System;

class PracticalLesson
{
	public string Description { get; }
	public string TaskLink { get; }
	public string SolutionLink { get; }

	public PracticalLesson(string description, string taskLink, string solutionLink)
	{
		Description = description;
		TaskLink = taskLink;
		SolutionLink = solutionLink;
	}
}
