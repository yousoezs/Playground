namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class DeleteUserRequest : IHttpRequest
    {
        public Guid Id { get; set; }
    }
}
