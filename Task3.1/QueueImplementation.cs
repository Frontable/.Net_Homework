using System;
using System.Collections.Generic;

public class Queue<T> : IQueue<T>
{
	private LinkedList<T> _elements = new LinkedList<T>();

	public void Enqueue(T element)
	{
		_elements.AddLast(element);
	}

	public T Dequeue()
	{
		if (IsEmpty())
		{
			throw new InvalidOperationException("Queue is empty");
		}

		T element = _elements.First.Value;
		_elements.RemoveFirst();
		return element;
	}

	public bool IsEmpty()
	{
		return _elements.Count == 0;
	}
}
