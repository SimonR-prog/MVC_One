namespace Domain.Models;

public class SuccessResponse : Response
{
    public SuccessResponse(int statusCode)
    {
        Success = true;
        StatusCode = statusCode;
    }
}
