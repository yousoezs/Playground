using MediatR;

namespace ASPNET.Product.API.MinimalAPI.Endpoints
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
