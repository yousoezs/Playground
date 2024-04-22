using Microsoft.AspNetCore.Mvc;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class GetUserByIdRequest : IHttpRequest
    {
        public required string Id { get; set; }
    }
}
