using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		// Create a training session
		Training training = new Training("Advanced C# Programming");

		// Add lectures and practical lessons
		Lecture lecture1 = new Lecture("Introduction to OOP");
		Lecture lecture2 = new Lecture("Data Structures");
		PracticalLesson practical1 = new PracticalLesson("Implement a linked list", "C# code for linked list");
		PracticalLesson practical2 = new PracticalLesson("Write unit tests", "Unit test cases");
		
		Training trainingTwo = new Training("Introduction to SDL");

		PracticalLesson practicalTwo_One = new PracticalLesson("Implement a linked list", "C# code for linked list");
		PracticalLesson practicalTwo_Two = new PracticalLesson("Write unit tests", "Unit test cases");

		training.Add(lecture1);
		training.Add(lecture2);
		training.Add(practical1);
		training.Add(practical2);
		
		
		trainingTwo.Add(practicalTwo_One);
		trainingTwo.Add(practicalTwo_Two);

		// Check if the training is practical-only
		Console.WriteLine($"Is practical-only: {training.IsPractical()}");

		// Clone the training
		Training clonedTraining = training.Clone();
		Console.WriteLine($"Cloned training description: {clonedTraining.Description}");
		
		Console.WriteLine($"Is practical-only: {trainingTwo.IsPractical()}");

		// Clone the training
		Training clonedTrainingTwo = trainingTwo.Clone();
		Console.WriteLine($"Cloned training description: {clonedTrainingTwo.Description}");
	}
}