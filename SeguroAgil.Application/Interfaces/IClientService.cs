using SeguroAgil.Domain.Entities;

namespace SeguroAgil.Application.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        Client GetClientById(string id);
        Client CreateClient(Client client);
        bool UpdateClient(string id, Client client);
        bool DeleteClient(string id);
    }
}
