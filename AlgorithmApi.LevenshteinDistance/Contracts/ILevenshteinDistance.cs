using AlgorithmApi.LevenshteinDistance.Models;

namespace AlgorithmApi.LevenshteinDistance.Contracts
{
	public interface ILevenshteinDistance
	{
		LevenshteinDistanceModel LevenshteinDistanceValue(string first, string second);
	}
}
