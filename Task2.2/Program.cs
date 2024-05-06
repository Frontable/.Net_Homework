using System;

class DiagonalMatrix
{
	private int[] diagonal;
	public int Size { get; }

	public DiagonalMatrix(params int[] diagonalElements)
	{
		if (diagonalElements == null)
		{
			Size = 0;
			diagonal = new int[0];
		}
		else
		{
			Size = diagonalElements.Length;
			diagonal = new int[Size];
			Array.Copy(diagonalElements, diagonal, Size);
		}
	}

	public int this[int i, int j]
	{
		get
		{
			if (i < 0 || i >= Size || j < 0 || j >= Size || i != j)
				return 0;
			return diagonal[i];
		}
		set
		{
			if (i >= 0 && i < Size && j >= 0 && j < Size && i == j)
				diagonal[i] = value;
		}
	}

	public int Track()
	{
		int sum = 0;
		for (int i = 0; i < Size; i++)
		{
			sum += diagonal[i];
		}
		return sum;
	}

	public override string ToString()
	{
		return $"Diagonal Matrix (Size: {Size})";
	}

	public string Output()
	{
		return $"{ToString()}\nTrack: {Track()}";
	}

	public override bool Equals(object obj)
	{
		if (!(obj is DiagonalMatrix otherMatrix) || otherMatrix.Size != Size)
			return false;

		for (int i = 0; i < Size; i++)
		{
			if (diagonal[i] != otherMatrix.diagonal[i])
				return false;
		}

		return true;
	}
}

static class DiagonalMatrixExtensions
{
	public static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
	{
		int maxSize = Math.Max(matrix1.Size, matrix2.Size);
		int[] resultDiagonal = new int[maxSize];

		for (int i = 0; i < maxSize; i++)
		{
			int element1 = (i < matrix1.Size) ? matrix1[i, i] : 0;
			int element2 = (i < matrix2.Size) ? matrix2[i, i] : 0;
			resultDiagonal[i] = element1 + element2;
		}

		return new DiagonalMatrix(resultDiagonal);
	}
}

class Program
{
	static void Main(string[] args)
	{
		DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3);
		DiagonalMatrix matrix2 = new DiagonalMatrix(4, 5, 6, 7);

		
		DiagonalMatrix sumMatrix = matrix1.Add(matrix2);

		
		Console.WriteLine(sumMatrix.Output());
	}
}
