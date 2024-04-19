using Microsoft.AspNetCore.Mvc;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class GetUserByIdRequest : IHttpRequest
    {
        [FromBody]
        public string Id { get; set; }
    }
}
