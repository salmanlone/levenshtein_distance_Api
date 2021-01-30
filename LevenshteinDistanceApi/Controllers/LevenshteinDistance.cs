﻿using AlgorithmApi.LevenshteinDistance.Contracts;
using AlgorithmApi.Utilities.APIKey;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LevenshteinDistance : ControllerBase
	{
		private readonly ILevenshteinDistance _levenshteinDistance;

		public LevenshteinDistance(ILevenshteinDistance levenshteinDistance)
		{
			_levenshteinDistance = levenshteinDistance;
		}

		[HttpPost("/compute")]
		[APIKeyValidationFilter("secretKey")]
		public ActionResult Get(string first, string second, [FromHeader] string secretKey)
		{
			var result = _levenshteinDistance.ComputeLevenshteinDistance(first, second);
			if (result == -1)
				return BadRequest();
			return Ok(result);
		}
	}
}
