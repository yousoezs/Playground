using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;
using ASPNET.User.BusinessLogic.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Model;
using MediatR;
using System.Text.Json;

namespace ASPNET.User.API.MinimalAPI.Endpoints.Handler.User
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, IResult>
    {
        private readonly IGenericRepository<UserModel, Guid> _repository;

        public AddUserHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            if(request.User is null)
                return Results.NotFound("User is null");
            if(request.User.Id.Equals(Guid.Empty))
                return Results.NotFound("Id is empty");

            var response = await _repository.AddEntity(request.User.ConvertToModel());
            if(!response.IsSuccess)
                return Results.NotFound(response.Message);
            
            await _repository.SaveAsync();

            return Results.Ok(response.Message);
        }
    }
}
