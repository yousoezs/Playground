using ASPNET.User.API.MinimalAPI.Extensions.EndpointsGrouped;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASPNET.User.API.MinimalAPI.Extensions
{
    public static class WebApplicationEndpointExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapGroup("/api/user").MapUserGroup().WithTags("Users");

            return app;
        }
    }
}
