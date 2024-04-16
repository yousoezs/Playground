
namespace ASPNET.Domain.Commons.Record
{
    public record ServiceResponse<T>(T? Data, bool IsSuccess, string Message);
}
