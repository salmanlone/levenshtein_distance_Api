using System;
using AlgorithmApi.LevenshteinDistance.Contracts;
using AlgorithmApi.LevenshteinDistance.Models;

namespace AlgorithmApi.LevenshteinDistance
{
	public class LevenshteinDistanceService : ILevenshteinDistance
	{
		public LevenshteinDistanceService()
		{

		}

		public LevenshteinDistanceModel LevenshteinDistanceValue(string first, string second)
		{
			return ComputeDistance(first, second);
		}

		private LevenshteinDistanceModel ComputeDistance(string first, string second)
		{
			if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second)) return null;

			if (string.IsNullOrEmpty(first)) first = "";

			if (string.IsNullOrEmpty(second)) second = "";

			int[,] d = CreateMatrix(first, second);

			FillUpMatrix(first, second, d);

			return new LevenshteinDistanceModel()
			{
				FirstInput = first,
				SecondInput = second,
				Distance = d[first.Length, second.Length],
				Matrix = d
			};
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
