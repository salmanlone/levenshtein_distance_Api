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
		public void IsReturnCorrect()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreEqual(result,5);
		}

		[Test]
		public void IsReturnInCorrect()
		{ 
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, second);
			Assert.AreNotEqual(result, 1);
		}

		[Test]
		public void IsReturnNegativeForFirstInput()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance("", second);
			Assert.Negative(result, "First input is negative");
		}

		[Test]
		public void IsReturnNegativeForSecondInput()
		{
			var result = levenshteinDistanceService.ComputeLevenshteinDistance(first, "");
			Assert.Negative(result, "First input is negative");
		}
	}
}