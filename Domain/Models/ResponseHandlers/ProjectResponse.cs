namespace Domain.Models.ResponseHandlers;

public class ProjectResponse : BaseResponse
{

}
public class ProjectResponse<T> : ProjectResponse
{
    public T? Content { get; set; }
}