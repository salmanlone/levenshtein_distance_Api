using AlgorithmApi.LevenshteinDistance;
using AlgorithmApi.LevenshteinDistance.Contracts;

namespace AlgorithmApi.Services
{
	public class LevenshteinDistance : ILevenshteinDistance
	{
		public LevenshteinDistance()
		{
		}

		public int ComputeLevenshteinDistance(string first, string second)
		{
			return new LevenshteinDistanceService().ComputeLevenshteinDistance(first, second);
		}
	}
}
