using SeguroAgil.Models;

namespace SeguroAgil.Services
{
    public interface IClientService
    {
        List<Client> GetClients();
        Client GetClientById(string id);
        Client CreateClient(Client client);
        bool UpdateClient(string id);
        bool DeleteClient(string id);
    }
}
