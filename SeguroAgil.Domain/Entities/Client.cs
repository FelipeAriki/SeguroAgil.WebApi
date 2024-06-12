using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroAgil.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("sobrenome")]
        public string Sobrenome { get; set; } = string.Empty;

        [BsonElement("idade")]
        public string Idade { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;


        //Endereço
        [BsonElement("rua")]
        public string Rua { get; set; } = string.Empty;

        [BsonElement("bairro")]
        public string Bairro { get; set; } = string.Empty;

        [BsonElement("cep")]
        public string Cep { get; set; } = string.Empty;

        [BsonElement("complemento")]
        public string Complemento { get; set; } = string.Empty;

        [BsonElement("numero")]
        public int Numero { get; set; }

    }
}
