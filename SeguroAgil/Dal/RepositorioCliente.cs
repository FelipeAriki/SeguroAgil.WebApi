using MongoDB.Driver;
using SeguroAgil.Models;

namespace SeguroAgil.Dal
{
    public class RepositorioCliente
    {
        private readonly IMongoCollection<Cliente> _collection;
        public RepositorioCliente(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<Cliente>(collectionName);
        }

        public List<Cliente> ObterTodos()
        {
            return _collection.Find(_ => true).ToList();
        }

        public void Inserir(Cliente exemplo)
        {
            _collection.InsertOne(exemplo);
        }
    }
}
