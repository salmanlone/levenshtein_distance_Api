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

			Object[,] d = CreateMatrix(first, second);

			FillUpMatrix(first, second, d);

			return new LevenshteinDistanceModel()
			{
				FirstInput = first,
				SecondInput = second,
				Distance = Convert.ToInt32(d[first.Length, second.Length]),
				Matrix = d
			};
		}

		private static Object[,] CreateMatrix(string first, string second)
		{
			char[] firstInputArray = first.ToCharArray();
			char[] secondInputArray = second.ToCharArray();

			var d = new Object[first.Length + 2, second.Length + 2];

			for (var i = 0; i < second.Length; i++)
			{
				d[0, i+2] = secondInputArray[i].ToString();
			}

			for (var j = 0; j < first.Length; j++)
			{
				d[j+2, 0] = firstInputArray[j].ToString();
			}

			for (var i = 0; i <= first.Length; i++)
			{
				d[i+1, 1] = i;
			}

			for (var j = 0; j <= second.Length; j++)
			{
				d[1, j+1] = j;
			}

			return d;
		}

		private void FillUpMatrix(string first, string second, Object[,] d)
		{
			for (var i = 2; i <= first.Length+1; i++)
			{
				for (var j = 2; j <= second.Length+1; j++)
				{
					if (second[j - 2] == first[i - 2])
						d[i, j] = d[i - 1, j - 1];
					else
						d[i, j] = Min((int)d[i - 1, j], (int)d[i, j - 1], (int)d[i - 1, j - 1]) + 1;
				}
			}
		}

		private int Min(int e1, int e2, int e3)
		{
			return Math.Min(Math.Min(e1, e2), e3);
		}
	}
}
