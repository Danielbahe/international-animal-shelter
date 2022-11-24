using CSharpFunctionalExtensions;

namespace Kindred.Infrastructure
{
    public static class ResultExtensions
    {
        public static Response<T> ToResponse<T>(this T result, ResponseCode code) where T : IResult
        {
            return Response<T>.Create(result, code);
        }

        public static Response ToResponse(this Result result, ResponseCode code)
        {
            return Response.Create(result, code);
        }
    }
}