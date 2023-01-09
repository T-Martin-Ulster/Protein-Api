namespace ProteinApi.Models;

public class ProteinIDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set;} = null!;

    public string ProduceCollectionName { get; set;} = null!;

    public string BatchCollectionName { get; set; } = null!;

    public string ProduceTransactionCollectionName { get; set; } = null!;

    public string TransactionRequestCollectionName { get; set; } = null!;

    public string FieldCollectionName { get; set; } = null!;

    public string BusinessCollectionName { get; set; } = null!;

}

