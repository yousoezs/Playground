using ASPNET.Domain.Commons.DTO;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class AddUserRequest : IHttpRequest
    {
        public required UserDto User { get; set; }
    }
}
