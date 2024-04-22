using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;
using ASPNET.User.BusinessLogic.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Model;
using MediatR;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Handler.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, IResult>
    {
        private readonly IGenericRepository<UserModel, Guid> _repository;

        public UpdateUserHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"UserDto: {request}");
            if(request.User is null)
                return Results.NotFound("User is null");

            var response = await _repository.UpdateEntity(request.User.ConvertToModel());
            if(!response.IsSuccess)
                return Results.NotFound(response.Message);

            await _repository.SaveAsync();
            return Results.Ok(response.Message);
        }
    }
}
