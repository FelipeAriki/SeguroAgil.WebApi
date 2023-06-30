using MongoDB.Driver;

namespace SeguroAgil.Models
{
    public class Banco
    {
        public Banco()
        {
            var client = new MongoClient("mongodb://localhost:27017");

        }
    }
}
