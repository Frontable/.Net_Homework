using System;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter the size of the queue:");
		int size = Convert.ToInt32(Console.ReadLine());

		IQueue<int> queue = new Queue<int>();

		Console.WriteLine("Enter the elements to enqueue:");
		for (int i = 0; i < size; i++)
		{
			int element = Convert.ToInt32(Console.ReadLine());
			queue.Enqueue(element);
		}

		

		IQueue<int> tailQueue = queue.Tail();
		Console.WriteLine("Elements after applying Tail<T> method:");
		while (!tailQueue.IsEmpty())
		{
			int element = tailQueue.Dequeue();
			Console.WriteLine(element);
		}
	}
}
