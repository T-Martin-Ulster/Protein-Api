namespace ProteinApi.Models;

public class ProteinIDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set;} = null!;

    public string TransactionsCollectionName { get; set;} = null!;

    public string ProductsCollectionName { get; set; } = null!;

    public string UsersCollectionName { get; set; } = null!;

}

