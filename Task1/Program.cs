using System;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter the number of elements in the array:");
		int n = int.Parse(Console.ReadLine());

		int[] originalArray = new int[n];
		Console.WriteLine("Enter the elements of the array:");

		for (int i = 0; i < n; i++)
		{
			originalArray[i] = int.Parse(Console.ReadLine());
		}

		Console.WriteLine("Original Array:");
		PrintArray(originalArray);

		int[] newArray = CreateNewArray(originalArray);
		Console.WriteLine("New Array:");
		PrintArray(newArray);
	}

	static int[] CreateNewArray(int[] array)
	{
		int[] newArray = new int[array.Length];
		int index = 0;

		for (int i = 0; i < array.Length; i++)
		{
			bool found = false;
			for (int j = 0; j < index; j++)
			{
				if (array[i] == newArray[j])
				{
					found = true;
					break;
				}
			}

			if (!found)
			{
				newArray[index] = array[i];
				index++;
			}
		}

		Array.Resize(ref newArray, index);
		return newArray;
	}

	static void PrintArray(int[] array)
	{
		foreach (var element in array)
		{
			Console.Write(element + " ");
		}
		Console.WriteLine();
	}
}
