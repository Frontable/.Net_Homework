class Training
{
	public string Description { get; }
	private List<Session> sessions = new List<Session>();

	public Training(string description)
	{
		Description = description;
	}

	public void Add(Session session)
	{
		sessions.Add(session);
	}

	public bool IsPractical()
	{
		return sessions.TrueForAll(session => session is PracticalLesson);
	}

	public Training Clone()
	{
		Training clonedTraining = new Training(Description);
		foreach (Session session in sessions)
		{
			if (session is Lecture lecture)
			{
				clonedTraining.Add(new Lecture(lecture.Topic));
			}
			else if (session is PracticalLesson practicalLesson)
			{
				clonedTraining.Add(new PracticalLesson(practicalLesson.TaskCondition, practicalLesson.Solution));
			}
		}
		return clonedTraining;
	}
}