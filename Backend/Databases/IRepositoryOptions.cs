namespace ZetsubouGacha.Databases
{
    public interface IRepositoryOptions
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }
    }
}
