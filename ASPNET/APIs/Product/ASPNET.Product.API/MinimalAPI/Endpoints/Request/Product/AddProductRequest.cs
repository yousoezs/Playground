using ASPNET.Domain.Commons.DTO;

namespace ASPNET.Product.API.MinimalAPI.Endpoints.Request.Product
{
    public class AddProductRequest : IHttpRequest
    {
        public required ProductDto Product { get; set; }
    }
}
