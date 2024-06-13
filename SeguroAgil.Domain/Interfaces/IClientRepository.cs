using SeguroAgil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroAgil.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(string id);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(string id);
    }
}
