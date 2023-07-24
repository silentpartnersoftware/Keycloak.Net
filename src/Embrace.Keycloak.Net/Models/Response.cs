using System.Net;

namespace Keycloak.Net.Models;

public class Response<T>
{
    public bool IsSuccessful { get; }
    public HttpStatusCode StatusCode { get; }
    public T Payload { get; }
    public string ErrorMessage { get; }

    public Response(int statusCode, T payload)
    {
        StatusCode = statusCode is >= 200 and <= 299 ? (HttpStatusCode)statusCode : HttpStatusCode.OK;
        Payload = payload;
        IsSuccessful = true;
    }
    
    public Response(HttpStatusCode statusCode, T payload)
    {
        StatusCode = (int)statusCode is >= 200 and <= 299 ? statusCode : HttpStatusCode.OK;
        Payload = payload;
        IsSuccessful = true;
    }
    
    public Response(int statusCode, string errorMessage)
    {
        StatusCode = statusCode >= 400 ? (HttpStatusCode)statusCode : HttpStatusCode.InternalServerError;
        ErrorMessage = errorMessage;
        IsSuccessful = false;
    }
    
    public Response(HttpStatusCode statusCode, string errorMessage)
    {
        StatusCode = (int)statusCode >= 400 ? statusCode : HttpStatusCode.InternalServerError;
        ErrorMessage = errorMessage;
        IsSuccessful = false;
    }
}