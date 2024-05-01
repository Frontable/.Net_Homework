using System;

class Matrix
{
	private int[] diagonal;
	public int Size { get; }

	public Matrix(params int[] diagonalElements)
	{
		if (diagonalElements == null)
		{
			Size = 0;
			diagonal = new int[0];
			return;
		}

		Size = diagonalElements.Length;
		diagonal = new int[Size];
		Array.Copy(diagonalElements, diagonal, Size);
	}

	public int this[int i, int j]
	{
		get
		{
			if (i < 0 || i >= Size || j < 0 || j >= Size || i != j)
				return 0;
			return diagonal[i];
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

	public override bool Equals(object obj)
	{
		if (!(obj is Matrix otherMatrix) || otherMatrix.Size != Size)
			return false;

		for (int i = 0; i < Size; i++)
		{
			if (diagonal[i] != otherMatrix.diagonal[i])
				return false;
		}

		return true;
	}

	public static Matrix Add(Matrix matrix1, Matrix matrix2)
	{
		int maxSize = Math.Max(matrix1.Size, matrix2.Size);
		int[] resultDiagonal = new int[maxSize];

		for (int i = 0; i < maxSize; i++)
		{
			int element1 = (i < matrix1.Size) ? matrix1.diagonal[i] : 0;
			int element2 = (i < matrix2.Size) ? matrix2.diagonal[i] : 0;
			resultDiagonal[i] = element1 + element2;
		}

		return new Matrix(resultDiagonal);
	}
}

static class MatrixExtensions
{
	public static Matrix Add(this Matrix matrix1, Matrix matrix2)
	{
		return Matrix.Add(matrix1, matrix2);
	}
}

class Program
{
	static void Main(string[] args)
	{
		Matrix matrix1 = new Matrix(1, 2, 3);
		Matrix matrix2 = new Matrix(4, 5, 6, 7);

		Matrix result = matrix1.Add(matrix2);

		Console.WriteLine(result);
		Console.WriteLine($"Track: {result.Track()}");
	}
}
