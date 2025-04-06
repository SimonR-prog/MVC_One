namespace Domain.Models.ResponseHandlers;

public class StatusResponse : BaseResponse
{

}
public class StatusResponse<T> : StatusResponse
{
    public T? Content { get; set; }
}