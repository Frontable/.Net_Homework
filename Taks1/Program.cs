using System;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter two integers:");
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());

		Console.WriteLine($"Numbers with exactly two 'A's in their duodecimal representation between {a} and {b} (inclusive):");
		for (int i = a; i <= b; i++)
		{
			if (CountAInDuodecimal(i) == 2)
			{
				Console.WriteLine($"{i} (in decimal)");
			}
		}
	}

	static int CountAInDuodecimal(int num)
	{
		int count = 0;
		while (num > 0)
		{
			if (num % 12 == 10) // 'A' in duodecimal representation
			{
				count++;
			}
			num /= 12;
		}
		return count;
	}
}
