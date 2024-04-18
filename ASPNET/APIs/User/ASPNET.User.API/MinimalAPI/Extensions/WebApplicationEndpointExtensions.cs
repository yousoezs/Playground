using ASPNET.User.API.MinimalAPI.Extensions.EndpointsGrouped;

namespace ASPNET.User.API.MinimalAPI.Extensions
{
    public static class WebApplicationEndpointExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapGroup("/users").MapUserGroup().WithTags("Users");
        }
    }
}
