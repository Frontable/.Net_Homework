using System;

class Point
{
	private int[] coordinates = new int[3];
	private double mass;

	public int X
	{
		get { return coordinates[0]; }
		set { coordinates[0] = value; }
	}

	public int Y
	{
		get { return coordinates[1]; }
		set { coordinates[1] = value; }
	}

	public int Z
	{
		get { return coordinates[2]; }
		set { coordinates[2] = value; }
	}

	public double Mass
	{
		get { return mass; }
		set { mass = value >= 0 ? value : 0; }
	}

	public bool IsZero()
	{
		return X == 0 && Y == 0 && Z == 0;
	}

	public double DistanceTo(Point nextPoint)
	{
		int deltaX = X - nextPoint.X;
		int deltaY = Y - nextPoint.Y;
		int deltaZ = Z - nextPoint.Z;

		return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
	}
}

class Program
{
	static void Main(string[] args)
	{
		Point point1 = new Point();
		point1.X = 1;
		point1.Y = 2;
		point1.Z = 3;
		point1.Mass = 10;

		Point point2 = new Point();
		point2.X = 4;
		point2.Y = 5;
		point2.Z = 6;
		point2.Mass = 15;

		Console.WriteLine($"Distance between point1 and point2: {point1.DistanceTo(point2)}");
	}
}
