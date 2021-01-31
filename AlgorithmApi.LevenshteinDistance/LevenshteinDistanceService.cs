using System;
using AlgorithmApi.LevenshteinDistance.Contracts;

namespace AlgorithmApi.LevenshteinDistance
{
	public class LevenshteinDistanceService : ILevenshteinDistance
	{
		public LevenshteinDistanceService()
		{

		}

		public int ComputeLevenshteinDistance(string first, string second)
		{
			return Compute(first, second);
		}

		private int Compute(string first, string second)
		{
			if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second)) return -1;

			if (string.IsNullOrEmpty(first)) return second.Length;

			if (string.IsNullOrEmpty(second)) return first.Length;

			int[,] d = CreateMatrix(first, second);

			FillUpMatrix(first, second, d);

			return d[first.Length, second.Length];
		}

		private static int[,] CreateMatrix(string first, string second)
		{
			var d = new int[first.Length + 1, second.Length + 1];

			for (var i = 0; i <= first.Length; i++)
			{
				d[i, 0] = i;
			}

			for (var j = 0; j <= second.Length; j++)
			{
				d[0, j] = j;
			}

			return d;
		}

		private void FillUpMatrix(string first, string second, int[,] d)
		{
			for (var i = 1; i <= first.Length; i++)
			{
				for (var j = 1; j <= second.Length; j++)
				{
					if (second[j - 1] == first[i - 1])
						d[i, j] = d[i - 1, j - 1];
					else
						d[i, j] = Min(d[i - 1, j], d[i, j - 1], d[i - 1, j - 1]) + 1;
				}
			}
		}

		private int Min(int e1, int e2, int e3)
		{
			return Math.Min(Math.Min(e1, e2), e3);
		}
	}
}
