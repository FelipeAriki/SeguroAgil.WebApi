namespace SeguroAgil.Interfaces
{
    public interface IClienteDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
