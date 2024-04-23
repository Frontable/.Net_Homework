using System;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter the first 9 digits of the ISBN:");
		string input = Console.ReadLine();

		int checkDigit = CalculateCheckDigit(input);

		string isbn = input + (checkDigit == 10 ? "X" : checkDigit.ToString());
		Console.WriteLine($"The complete ISBN is: {isbn}");
	}

	static int CalculateCheckDigit(string input)
	{
		int sum = 0;
		for (int i = 0; i < input.Length; i++)
		{
			int digit = int.Parse(input[i].ToString());
			sum += (10 - i) * digit;
		}

		int remainder = sum % 11;
		int checkDigit = (remainder == 0) ? 0 : (11 - remainder);
		return checkDigit;
	}
}
