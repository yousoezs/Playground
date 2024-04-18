using ASPNET.User.API.MinimalAPI.Endpoints;
using MediatR;

namespace ASPNET.User.API.MinimalAPI.Extensions
{
    public static class MinimalatRExtensions
    {
        public static RouteGroupBuilder MediateGet<TRequest>(this RouteGroupBuilder builder, string pattern) where TRequest : IHttpRequest 
        {
            builder.MapGet(pattern, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

            return builder;
        }
        public static RouteGroupBuilder MediatePost<TRequest>(this RouteGroupBuilder builder, string pattern) where TRequest : IHttpRequest
        {
            builder.MapGet(pattern, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

            return builder;
        }
        public static RouteGroupBuilder MediateDelete<TRequest>(this RouteGroupBuilder builder, string pattern) where TRequest : IHttpRequest
        {
            builder.MapGet(pattern, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

            return builder;
        }
        public static RouteGroupBuilder MediatePut<TRequest>(this RouteGroupBuilder builder, string pattern) where TRequest : IHttpRequest
        {
            builder.MapGet(pattern, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

            return builder;
        }
    }
}
