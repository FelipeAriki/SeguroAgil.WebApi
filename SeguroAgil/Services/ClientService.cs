using MongoDB.Driver;
using SeguroAgil.Interfaces;
using SeguroAgil.Models;

namespace SeguroAgil.Services
{
    public class ClientService : IClientService
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientService(IClientDatabaseSettings settings, IMongoClient mongoClient)
        {
           var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _clients = dataBase.GetCollection<Client>(settings.CollectionName);
        }
        public Client CreateClient(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public bool DeleteClient(string id)
        {
            throw new NotImplementedException();
        }

        public Client GetClientById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(string id)
        {
            throw new NotImplementedException();
        }
    }
}
