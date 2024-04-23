namespace ASPNET.Product.API.MinimalAPI.Endpoints.Request.Product
{
    public class GetByIdProductRequest : IHttpRequest
    {
        public required string Id { get; set; }
    }
}
