using AlgorithmApi.LevenshteinDistance.Contracts;
using AlgorithmApi.Models;
using AlgorithmApi.Utilities.APIKey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
		[AllowAnonymous]
		public ActionResult Get(Request request, [FromHeader] string secretKey)
		{
			var result = _levenshteinDistance.LevenshteinDistanceValue(request.FirstInput, request.SecondInput);
			if (result == null)
				return BadRequest();
			return Ok(JsonConvert.SerializeObject(result));
		}
	}
}
