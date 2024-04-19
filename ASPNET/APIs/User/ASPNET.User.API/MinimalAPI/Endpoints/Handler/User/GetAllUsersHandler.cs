using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;
using ASPNET.User.BusinessLogic.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Model;
using MediatR;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Handler.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IResult>
    {
        private readonly IGenericRepository<UserModel, Guid> _repository;

        public GetAllUsersHandler(UserRepository repository)
        {
            _repository = repository;
        }
        public async Task<IResult> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            if(request is null)
                return Results.NotFound("Request is null");

            var response = await _repository.GetAllEntities();

            return Results.Ok(response.Data.Select(users => users.ConvertToDto()));
        }
    }
}
