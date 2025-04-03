using Domain.Interfaces;

namespace Domain.Models;

public abstract class Response : IResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public int StatusCode { get; set; }


    public static Response Ok()
    {
        return new SuccessResponse(200);
    }
    public static Response BadRequest(string message)
    {
        return new ErrorResponse(400, message);
    }
    public static Response NotFound(string message)
    {
        return new ErrorResponse(404, message);
    }
    public static Response Error(string message)
    {
        return new ErrorResponse(500, message);
    }
    public static Response AlreadyExists(string message)
    {
        return new ErrorResponse(409, message);
    }
}
public class Response<T> : Response, IResponseContent<T>
{
    public T? Content { get; private set; }

    public static Response<T> Ok(T? content)
    {
        return new Response<T>
        {
            Success = true,
            StatusCode = 200,
            Content = content
        };
    }
    public static Response<T> Error(T? content, string message)
    {
        return new Response<T>
        {
            Success = false,
            StatusCode = 500,
            Content = content,
            ErrorMessage = message
        };
    }
    public static Response<T> NotFound(T? content, string message)
    {
        return new Response<T>
        {
            Success = false,
            StatusCode = 404,
            Content = content,
            ErrorMessage = message
        };
    }
}