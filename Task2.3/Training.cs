using System;
using System.Linq;

class Training
{
	private Lesson[] lessons = new Lesson[0];

	public void Add(Lesson lesson)
	{
		Array.Resize(ref lessons, lessons.Length + 1);
		lessons[lessons.Length - 1] = lesson;
	}

	public bool IsPractical()
	{
		return lessons.All(lesson => lesson is PracticalLesson);
	}

	public Training Clone()
	{
		Training clonedTraining = new Training();

		foreach (var lesson in lessons)
		{
			if (lesson is Lecture lecture)
			{
				clonedTraining.Add(new Lecture(lecture.Description, lecture.Topic));
			}
			else if (lesson is PracticalLesson practicalLesson)
			{
				clonedTraining.Add(new PracticalLesson(practicalLesson.Description, practicalLesson.TaskLink, practicalLesson.SolutionLink));
			}
		}

		return clonedTraining;
	}
}
