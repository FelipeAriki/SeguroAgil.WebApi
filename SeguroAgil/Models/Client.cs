using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeguroAgil.Models
{
    [BsonIgnoreExtraElements]
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("sobrenome")]
        public string Sobrenome { get; set; } = string.Empty;

        [BsonElement("idade")]
        public Date? Idade { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;


        //Endereço
        [BsonElement("rua")]
        public string Rua { get; set; } = string.Empty;

        [BsonElement("bairro")]
        public string Bairro { get; set; } = string.Empty;

        [BsonElement("cep")]
        public string Cep { get; set; } = string.Empty;

        [BsonElement("logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [BsonElement("complemento")]
        public string Complemento { get; set; } = string.Empty;

        [BsonElement("numero")]
        public int Numero { get; set; }

    }
}
