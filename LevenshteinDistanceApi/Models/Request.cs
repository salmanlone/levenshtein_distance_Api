using System.ComponentModel.DataAnnotations;

namespace AlgorithmApi.Models
{
	public class Request
	{
		[StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
		public string FirstInput { get; set; }
		[StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
		public string SecondInput { get; set; }
	}
}
