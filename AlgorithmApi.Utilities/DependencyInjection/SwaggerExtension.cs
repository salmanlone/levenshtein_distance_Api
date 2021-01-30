using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmApi.Utilities.DependencyInjection
{
	public static class SwaggerExtension
	{
		public static void InjectSwaggerServices(this IServiceCollection services, string APITitle, IConfiguration configuration)
		{
			OpenApiInfo swaggerDoc = new OpenApiInfo()
			{
				Title = APITitle,
				Version = configuration.GetValue<string>("Swagger:Version") ?? "v1",
				Description = configuration.GetValue<string>("Swagger:Description") ?? APITitle + " Description"
			};
			if (configuration.GetSection("Swagger:Contact").Exists())
			{
				Uri uri = null;
				Uri.TryCreate(configuration.GetValue<string>("Swagger:Contact:Url"), UriKind.Absolute, out uri);
				swaggerDoc.Contact = new OpenApiContact()
				{
					Name = configuration.GetValue<string>("Swagger:Contact:Name") ?? "Salman",
					Email = configuration.GetValue<string>("Swagger:Contact:Email") ?? "salmanlone89@gmail.com",
					Url = uri
				};
				services.AddSwaggerGen(c =>
				{
					c.SwaggerDoc(swaggerDoc.Version, swaggerDoc);
				});
			}
		}
	}
}
