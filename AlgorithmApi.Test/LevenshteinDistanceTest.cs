using AlgorithmApi.LevenshteinDistance;
using NUnit.Framework;

namespace AlgorithmApi.Test
{
	public class LevenshteinDistanceTest
	{
		string first = "";
		string second = "";
		LevenshteinDistanceService levenshteinDistanceService;

		[SetUp]
		public void Setup()
		{
			_ = new LevenshteinDistanceService();
			first = "Salman";
			second = "Tariq";
			levenshteinDistanceService = new LevenshteinDistanceService();
		}

		[Test]
		public void Correct()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreEqual(result, 5);
		}

		[Test]
		public void InCorrect()
		{ 
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreNotEqual(result, 1);
		}

		[Test]
		public void Negative()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance("", "");
			Assert.Negative(result, "Both inputs are null");
		}

		[Test]
		public void FirstInputLength()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, "");
			Assert.AreEqual(result, first.Length);
		}

		[Test]
		public void SecondInputLength()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance("", second);
			Assert.AreEqual(result, second.Length);
		}
	}
}