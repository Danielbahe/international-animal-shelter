using Microsoft.AspNetCore.Mvc;
using Kindred.Infrastructure;
using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult MapToHttpResponse<T>(Response<T> response, string uri = null, object value = null)
        {
            return response.ResponseCode switch
            {
                ResponseCode.Success => value == null ? Ok(response.Result.Value) : Ok(value),
                ResponseCode.Created => Created(uri, value),
                ResponseCode.ValidationError => BadRequest(response.Result.Error),
                ResponseCode.NotFound => NotFound(response.Result.Error),
                _ => StatusCode(500, response.Result.Error),
            };
        }

        public IActionResult MapToHttpResponse(Response response, string uri = null)
        {
            return response.ResponseCode switch
            {
                ResponseCode.Success => Ok(),
                ResponseCode.Created => Created(uri, null),
                ResponseCode.ValidationError => BadRequest(response.Result.Error),
                ResponseCode.NotFound => NotFound(response.Result.Error),
                _ => StatusCode(500, response.Result.Error),
            };
        }
    }
}
