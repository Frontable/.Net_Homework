using System;

class Program
{
	static void Main(string[] args)
	{
		Lecture lectureOne = new Lecture("Introduction", "Basic Concepts");
		Lecture lectureTwo = new Lecture("Data Structures", "Arrays and Lists");

		PracticalLesson firstPractical = new PracticalLesson("Task 1", "task1.com", "solution1.com");
		PracticalLesson secondPractical = new PracticalLesson("Task 2", "task2.com", "solution2.com");

		Training firstTraining = new Training();
		firstTraining.Add(lectureOne);
		firstTraining.Add(firstPractical);

		Console.WriteLine("Is the first training practical? " + firstTraining.IsPractical());

		Training firstClonedTraining = firstTraining.Clone();

		

		Training secondTraining = new Training();
		//secondTraining.Add(lectureTwo);
		secondTraining.Add(secondPractical);

		Console.WriteLine("Is the second training practical? " + secondTraining.IsPractical());

		Training secondClonedTraining = secondTraining.Clone();

		
	}
}
