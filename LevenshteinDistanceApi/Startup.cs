using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AlgorithmApi.Utilities.Swagger;
using AlgorithmApi.Utilities.DependencyInjection;
using AlgorithmApi.LevenshteinDistance.Contracts;
using AlgorithmApi.LevenshteinDistance;

namespace AlgorithmApi
{
	public class Startup
	{
		private const string API_NAME = "AlgorithmApi";
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ILevenshteinDistance, LevenshteinDistanceService>();
			services.AddControllers();
			services.InjectSwaggerServices(API_NAME, Configuration);
			services.InjectAPIKeyService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> log, IConfiguration config)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwaggerMiddleware(API_NAME, config);


			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
