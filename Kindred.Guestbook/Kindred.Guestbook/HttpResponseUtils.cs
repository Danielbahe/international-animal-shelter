using Kindred.Infrastructure;

namespace Kindred.Guestbook.Api
{
    public static class HttpResponseUtils
    {
        public static IResult ToHttpResponse<T>(this Response<T> response, string uri)
        {
            return response.ResponseCode switch
            {
                ResponseCode.Success => Results.Ok(response.Result.Value),
                ResponseCode.Created => Results.Created(uri, null),
                ResponseCode.ValidationError => Results.BadRequest(response.Result.Error),
                ResponseCode.NotFound => Results.NotFound(),
                _ => Results.StatusCode(500),
            };
        }
    }
}
