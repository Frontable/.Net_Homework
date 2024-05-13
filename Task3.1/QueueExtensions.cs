public static class QueueExtensions
{
	public static IQueue<T> Tail<T>(this IQueue<T> queue)
	{
		IQueue<T> newQueue = new Queue<T>();

		if (!queue.IsEmpty())
		{
			queue.Dequeue(); // Remove the first element
			while (!queue.IsEmpty())
			{
				newQueue.Enqueue(queue.Dequeue());
			}
		}

		return newQueue;
	}
}
