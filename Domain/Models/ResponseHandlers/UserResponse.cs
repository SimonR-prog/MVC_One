namespace Domain.Models.ResponseHandlers;

public class UserResponse : BaseResponse
{

}
public class UserResponse<T> : UserResponse
{
    public T? Content { get; set; }
}