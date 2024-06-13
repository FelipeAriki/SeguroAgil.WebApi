using SeguroAgil.Application.Interfaces;
using SeguroAgil.Domain.Entities;
using SeguroAgil.Domain.Interfaces;

namespace SeguroAgil.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            var clientCreated = await _clientRepository.CreateClientAsync(client);
            return clientCreated;
        }

        public async Task<bool> DeleteClientAsync(string id)
        {
            var clientRemoved = await _clientRepository.DeleteClientAsync(id);
            if(clientRemoved)
                return true;
            return false;
        }

        public async Task<Client> GetClientByIdAsync(string id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            return client == null ? throw new Exception($"Entity could not be loaded.") : client;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetClientsAsync();
            return clients == null ? throw new Exception($"Entity could not be loaded.") : clients;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            return await _clientRepository.UpdateClientAsync(client);
        }
    }
}
