using MongoDB.Bson;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeguroAgil.Models
{
    public class Cliente
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Date Idade { get; set; }
        public string Email { get; set; }

        //Endereço
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }

        public Cliente()
        {

        }
    }
}
