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

        public Client GetClientById(string id)
        {
            return _clients.Find(cli => cli.Id == id).FirstOrDefault();
        }

        public List<Client> GetClients()
        {
            return _clients.Find(client => true).ToList();
        }

        public bool UpdateClient(string id, Client client)
        {
            try
            {
                _clients.ReplaceOne(cli => cli.Id == id, client);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
