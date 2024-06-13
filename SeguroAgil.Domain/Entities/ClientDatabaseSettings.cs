using SeguroAgil.Domain.Interfaces;

namespace SeguroAgil.Domain.Entities
{
    public class ClientDatabaseSettings : IClientDatabaseSettings
    {
        public string CollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
