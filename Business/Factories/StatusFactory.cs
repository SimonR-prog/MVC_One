using Data.Entities;
using Domain.Models;

namespace Business.Factories;

public class StatusFactory
{
    public static Status Create(StatusEntity entity)
    {
        var status = new Status()
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };
        return status;
    }
}
