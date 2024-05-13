class PracticalLesson : Session
{
	public string TaskCondition { get; }
	public string Solution { get; }

	public PracticalLesson(string taskCondition, string solution)
	{
		TaskCondition = taskCondition;
		Solution = solution;
	}
}