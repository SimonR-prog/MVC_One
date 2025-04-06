namespace Domain.Models.ResponseHandlers;

public abstract class BaseResponse
{
    public bool Success { get; set; }
    public int? StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
}
