namespace ResponseModel.Interfaces
{
    public interface IResponse
    {
        string? ErrorMessage { get; set; }
        int StatusCode { get; set; }
        bool Success { get; set; }
    }
}