using ASPNET.Domain.Commons.DTO;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class UpdateUserRequest : IHttpRequest
    {
        public UserDto? User { get; set; }
    }
}
