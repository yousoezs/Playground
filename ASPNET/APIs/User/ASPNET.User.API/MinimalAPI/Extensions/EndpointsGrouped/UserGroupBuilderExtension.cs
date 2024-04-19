using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;

namespace ASPNET.User.API.MinimalAPI.Extensions.EndpointsGrouped
{
    public static class UserGroupBuilderExtension
    {
        public static RouteGroupBuilder MapUserGroup(this RouteGroupBuilder builder)
        {
            builder.MediateGet<GetAllUsersRequest>("/getAll");
            builder.MediateGet<GetUserByIdRequest>("/getById/{id}");
            builder.MediatePost<AddUserRequest>("/add");
            builder.MediatePut<UpdateUserRequest>("/update");
            builder.MediateDelete<DeleteUserRequest>("/delete/{id}");

            return builder;
        }
    }
}
