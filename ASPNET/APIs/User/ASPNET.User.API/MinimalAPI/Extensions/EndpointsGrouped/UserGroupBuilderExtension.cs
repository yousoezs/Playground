using ASPNET.User.API.MinimalAPI.Endpoints.Request.User;

namespace ASPNET.User.API.MinimalAPI.Extensions.EndpointsGrouped
{
    public static class UserGroupBuilderExtension
    {
        public static RouteGroupBuilder MapUserGroup(this RouteGroupBuilder builder)
        {
            builder.MediateGet<GetAllUsersRequest>("/all");
            builder.MediateGet<GetUserByIdRequest>("/{id}");
            builder.MediatePost<AddUserRequest>("/");
            builder.MediatePut<UpdateUserRequest>("/");
            builder.MediateDelete<DeleteUserRequest>("/{id}");

            return builder;
        }
    }
}
