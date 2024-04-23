using ASPNET.Product.API.MinimalAPI.Endpoints.Request.Product;

namespace ASPNET.Product.API.MinimalAPI.Extensions.EndpointsGrouped
{
    public static class ProductGroupBuilderExtension
    {
        public static RouteGroupBuilder MapProductGroup(this RouteGroupBuilder builder)
        {
            builder.MediateGet<GetAllProductsRequest>("/getAll");
            builder.MediateGet<GetByIdProductRequest>("/getById/{id}");
            builder.MediatePost<AddProductRequest>("/add");
            builder.MediatePut<UpdateProductRequest>("/update");
            builder.MediateDelete<DeleteProductRequest>("/delete/{id}");

            return builder;
        }
    }
}
