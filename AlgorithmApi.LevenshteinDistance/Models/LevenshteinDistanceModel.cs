using System;

namespace AlgorithmApi.LevenshteinDistance.Models
{
	public class LevenshteinDistanceModel
	{
		public string FirstInput { get; set; }

		public string SecondInput { get; set; }

		public int Distance { get; set; }

		public Object[,] Matrix { get; set; }
	}
}
