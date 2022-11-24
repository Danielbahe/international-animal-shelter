using Kindred.Infrastructure;

namespace Kindred.Guestbook.Api
{
    public static class HttpResponseUtils
    {
        public static IResult ToHttpResponse<T>(this Response<T> response, string uri = null, object value = null)
        {
            return response.ResponseCode switch
            {
                ResponseCode.Success => value == null ? Results.Ok(response.Result.Value) : Results.Ok(value),
                ResponseCode.Created => Results.Created(uri, null),
                ResponseCode.ValidationError => Results.BadRequest(response.Result.Error),
                ResponseCode.NotFound => Results.NotFound(),
                _ => Results.StatusCode(500),
            };
        }

        public static IResult ToHttpResponse(this Response response, string uri = null, object value = null)
        {
            return response.ResponseCode switch
            {
                ResponseCode.Success => Results.Ok(),
                ResponseCode.Created => Results.Created(uri, null),
                ResponseCode.ValidationError => Results.BadRequest(response.Result.Error),
                ResponseCode.NotFound => Results.NotFound(),
                _ => Results.StatusCode(500),
            };
        }
    }
}
