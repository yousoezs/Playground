namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class DeleteUserRequest : IHttpRequest
    {
        public string Id { get; set; }
    }
}
