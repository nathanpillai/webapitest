using Microsoft.OpenApi.Models;
using ProductApi.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProductApi.Extensions
{
    public static class ServiceExtensions
    {
        //service
        public static void ConfigureProductWrapper(this IServiceCollection services)
        {
            services.AddScoped<IProductDBContext, ProductDBContext>();
        }
    }
    public class AddCustomHeaderParameter
    : IOperationFilter
    {
        public void Apply(
            OpenApiOperation operation,
            OperationFilterContext context)
        {
            if (operation.Parameters is null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "XApiKey",
                In = ParameterLocation.Header,
                Description = "Api Key",
                Required = true,
            });
        }
    }
}