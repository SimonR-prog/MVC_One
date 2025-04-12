using Data.Entities;
using Domain.Models;

namespace Business.Factories;

public class ClientFactory
{
    public static Client Create(ClientEntity entity)
    {
        if (entity == null) { return null!; }
        var client = new Client()
        {
            Id = entity.Id,
            ClientName = entity.ClientName
        };
        return client;
    }
}
