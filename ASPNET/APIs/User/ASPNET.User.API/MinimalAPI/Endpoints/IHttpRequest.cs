using MediatR;

namespace ASPNET.User.API.MinimalAPI.Endpoints
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
