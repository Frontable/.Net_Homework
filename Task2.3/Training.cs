using System;
using System.Collections.Generic;
using System.Linq;

class Training
{
	private List<object> contents = new List<object>();

	public void Add(Lecture lecture)
	{
		contents.Add(lecture);
	}

	public void Add(PracticalLesson practicalLesson)
	{
		contents.Add(practicalLesson);
	}

	public bool IsPractical()
	{
		return contents.All(item => item is PracticalLesson);
	}

	public Training Clone()
	{
		Training clonedTraining = new Training();

		foreach (var item in contents)
		{
			if (item is Lecture lecture)
			{
				clonedTraining.Add(new Lecture(lecture.Description, lecture.Topic));
			}
			else if (item is PracticalLesson practicalLesson)
			{
				clonedTraining.Add(new PracticalLesson(practicalLesson.Description, practicalLesson.TaskLink, practicalLesson.SolutionLink));
			}
		}

		return clonedTraining;
	}
}
