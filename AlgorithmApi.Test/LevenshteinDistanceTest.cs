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
			first = "salman";
			second = "lone";
			levenshteinDistanceService = new LevenshteinDistanceService();
		}

		[Test]
		public void IsReturnCorrectResult()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreEqual(result,5);
		}

		[Test]
		public void IsReturnInCorrectResult()
		{ 
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreNotEqual(result, 1);
		}

		[Test]
		public void IsReturnNegativeResult()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance("", second);
			Assert.Negative(result, "First input is negative");
		}

		[Test]
		public void IsReturnNegativeResultAgain()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, "");
			Assert.Negative(result, "First input is negative");
		}
	}
}