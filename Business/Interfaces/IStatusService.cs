using Domain.Interfaces;
using Domain.Models;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<IResponseContent<IEnumerable<Status?>>> GetAllStatusAsync();
    }
}