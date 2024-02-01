using System.Net;

namespace Keycloak.Net.Models;

public class Response<T>
{
    public bool IsSuccessful { get; }
    public HttpStatusCode StatusCode { get; }
    public T Payload { get; }
    public string ErrorMessage { get; }

    private Response(int statusCode, T payload)
    {
        StatusCode = statusCode is >= 200 and <= 299 ? (HttpStatusCode) statusCode : HttpStatusCode.OK;
        Payload = payload;
        IsSuccessful = true;
    }

    private Response(int statusCode, string errorMessage)
    {
        StatusCode = statusCode >= 400 ? (HttpStatusCode) statusCode : HttpStatusCode.InternalServerError;
        ErrorMessage = errorMessage;
        IsSuccessful = false;
    }

    public static Response<T> Success(int statusCode, T payload) => new Response<T>(statusCode, payload);
    public static Response<T> Success(HttpStatusCode statusCode, T payload) => new Response<T>((int) statusCode, payload);
    public static Response<T> Failure(int statusCode, string errorMessage) => new Response<T>(statusCode, errorMessage);
    public static Response<T> Failure(HttpStatusCode statusCode, string errorMessage) => new Response<T>((int) statusCode, errorMessage);
}