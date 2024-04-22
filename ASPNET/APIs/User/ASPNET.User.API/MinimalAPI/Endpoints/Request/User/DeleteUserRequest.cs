namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class DeleteUserRequest : IHttpRequest
    {
        public required string Id { get; set; }
    }
}
