using AlgorithmApi.Utilities.APIKey;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmApi.Utilities.DependencyInjection
{
	public static class APIKeyInjectionExtension
	{
		public static void InjectAPIKeyService(this IServiceCollection services) =>
			services.AddSingleton<IAPIKeyValidator, APIKeyValidator>();
	}
}
