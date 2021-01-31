using AlgorithmApi.LevenshteinDistance;
using AlgorithmApi.LevenshteinDistance.Models;
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
		public void CorrectObject()
		{
			var result = levenshteinDistanceService.LevenshteinDistanceValue(first, second);
			Assert.IsInstanceOf<LevenshteinDistanceModel>(result);
		}

		[Test]
		public void CorrectValue()
		{
			var result = levenshteinDistanceService.LevenshteinDistanceValue(first, second);
			Assert.AreEqual(result.Distance, 5);
		}

		[Test]
		public void InCorrectValue()
		{ 
			var result = levenshteinDistanceService.LevenshteinDistanceValue(first, second);
			Assert.AreNotEqual(result.Distance, 1);
		}

		[Test]
		public void NullObject()
		{
			var result = levenshteinDistanceService.LevenshteinDistanceValue("", "");
			Assert.IsNull(result, "Both inputs are null");
		}

		[Test]
		public void FirstInputLength()
		{
			var result = levenshteinDistanceService.LevenshteinDistanceValue(first, "");
			Assert.AreEqual(result.Distance, first.Length);
		}

		[Test]
		public void SecondInputLength()
		{
			var result = levenshteinDistanceService.LevenshteinDistanceValue("", second);
			Assert.AreEqual(result.Distance, second.Length);
		}
	}
}