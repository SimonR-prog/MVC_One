using Domain.Models;
using Domain.Models.ResponseHandlers;


namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<StatusResponse<IEnumerable<Status?>>> GetAllStatusAsync();
    }
}