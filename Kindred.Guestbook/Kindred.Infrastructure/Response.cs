using CSharpFunctionalExtensions;

namespace Kindred.Infrastructure
{
    public enum ResponseCode
    {
        None = 0,
        Success = 200,
        Created = 201,
        ValidationError = 400,
        NotFound = 404,

    }

    public struct Response<T>
    {
        public Result<T> Result { get; private set; }
        public ResponseCode ResponseCode { get; private set; }

        public static Response<T> Create<T>(Result<T> result, ResponseCode code)
        {
            var response = new Response<T>
            {
                Result = result,
                ResponseCode = code
            };

            return response;
        }
    }
}