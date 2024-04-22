using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;
using ASPNET.User.BusinessLogic.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Model;
using MediatR;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Handler.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, IResult>
    {
        private IGenericRepository<UserModel, Guid> _repository;

        public GetUserByIdHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out Guid userID))
                return Results.NotFound("Id is not valid");

            var response = await _repository.GetEntity(userID);
            if(!response.IsSuccess)
                return Results.NotFound(response.Message);
            
            return Results.Ok(response.Message);
        }
    }
}
