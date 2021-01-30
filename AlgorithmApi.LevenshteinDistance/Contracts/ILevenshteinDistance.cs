namespace AlgorithmApi.LevenshteinDistance.Contracts
{
	public interface ILevenshteinDistance
	{
		int ComputeLevenshteinDistance(string first, string second);
	}
}
