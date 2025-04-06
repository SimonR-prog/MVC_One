namespace Domain.Models.ResponseHandlers;

public class ClientResponse : BaseResponse
{
    
}
public class ClientResponse<T> : ClientResponse
{
    public T? Content { get; set; }
}