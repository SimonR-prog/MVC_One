namespace ResponseModel.Models;

public class ErrorResponse : Response
{
    public ErrorResponse(int statusCode, string message)
    {
        Success = false;
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}