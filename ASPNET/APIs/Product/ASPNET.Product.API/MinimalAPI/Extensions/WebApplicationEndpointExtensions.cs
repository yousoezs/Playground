using ASPNET.Product.API.MinimalAPI.Extensions.EndpointsGrouped;

namespace ASPNET.Product.API.MinimalAPI.Extensions
{
    public static class WebApplicationEndpointExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapGroup("/api/product").MapProductGroup().WithTags("Products");

            return app;
        }
    }
}
