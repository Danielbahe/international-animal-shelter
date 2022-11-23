using CSharpFunctionalExtensions;

namespace Kindred.Infrastructure
{
    public static class ResultExtensions
    {
        public static Response<T> ToResponse<T>(this T result, ResponseCode code) where T : IResult
        {
            return Response<T>.Create<T>(result, code);
        }
    }
}