namespace Domain.Models.ResponseHandlers;

public class RepositoryResponse : BaseResponse
{

}

public class RepositoryResponse<T> : RepositoryResponse
{
    public T? Content { get; set; }
}