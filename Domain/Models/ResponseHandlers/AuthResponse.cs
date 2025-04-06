namespace Domain.Models.ResponseHandlers;

public class AuthResponse : BaseResponse
{

}
public class AuthResponse<T> : AuthResponse
{
    public T? Content { get; set; }
}