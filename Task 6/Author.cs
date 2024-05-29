using System;

public class Author
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }

	public Author() { }

	public Author(string firstName, string lastName, DateTime dateOfBirth)
	{
		FirstName = firstName;
		LastName = lastName;
		DateOfBirth = dateOfBirth;
	}
}
