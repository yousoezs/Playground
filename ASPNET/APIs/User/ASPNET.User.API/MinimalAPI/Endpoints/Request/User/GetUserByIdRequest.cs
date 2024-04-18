namespace ASPNET.User.API.MinimalAPI.Endpoints.Request.User
{
    public class GetUserByIdRequest : IHttpRequest
    {
        public Guid Id { get; set; }
    }
}
