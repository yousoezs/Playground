using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Model;
using MediatR;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Handler.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, IResult>
    {
        private readonly IGenericRepository<UserModel, Guid> _repository;

        public DeleteUserHandler(UserRepository repository)
        {
            _repository = repository;
        }
        public async Task<IResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            if(!Guid.TryParse(request.Id, out Guid userId))
                return Results.NotFound("Id is empty");

            var getUserResponse = await _repository.GetEntity(userId);
            if(!getUserResponse.IsSuccess)
                return Results.NotFound(getUserResponse.Message);

            var deletedUserResponse = await _repository.DeleteEntity(userId);
            if(!deletedUserResponse.IsSuccess)
                return Results.NotFound(deletedUserResponse.Message);

            await _repository.SaveAsync();
            return Results.Ok(deletedUserResponse.Message);
        }
    }
}
