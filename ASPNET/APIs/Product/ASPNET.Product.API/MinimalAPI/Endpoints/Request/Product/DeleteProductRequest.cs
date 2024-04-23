namespace ASPNET.Product.API.MinimalAPI.Endpoints.Request.Product
{
    public class DeleteProductRequest : IHttpRequest
    {
        public required string Id { get; set; }
    }
}
