using MongoDB.Driver;
using SeguroAgil.Domain.Entities;
using SeguroAgil.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroAgil.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientRepository(IClientDatabaseSettings settings, IMongoClient mongoClient)
        {
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _clients = dataBase.GetCollection<Client>(settings.CollectionName);
        }
        public async Task<Client> CreateClientAsync(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public async Task<bool> DeleteClientAsync(string id)
        {
            try
            {
                _clients.DeleteOne(cli => cli.Id == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Client> GetClientByIdAsync(string id)
        {
            return _clients.Find(cli => cli.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return _clients.Find(client => true).ToList();
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            try
            {
                _clients.ReplaceOne(cli => cli.Id == client.Id, client);
                return client;
            }
            catch
            {
                return new Client();
            }
        }
    }
}
