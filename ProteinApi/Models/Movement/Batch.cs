using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Batch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BatchId { get; set; }

    public string OwnerId { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public double Quantity { get; set; }

    public string QuantityType { get; set; } = null!; //No OR Kg

    public string? ParentId { get; set; } //BatchId

    //IOTA message
    public string MessageId { get; set; } = null!;

    public string ProductMessageId { get; set; } = null!;

    public string BusinessMessageId { get; set; } = null!;

    public string? TransactionMessageId { get; set; }

}
