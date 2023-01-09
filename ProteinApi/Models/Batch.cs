using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Batch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BatchId { get; set; }

    public DateTime BatchDate { get; set; }

    public string OwnerId { get; set; } = null!;

    public bool InStock { get; set; }

    //Produce
    public string[] ProduceID { get; set; } = null!; 

    public string ProduceType { get; set; } = null!;

    public double Quantity { get; set; } //No.

    public double Weight { get; set; } //Kg

    public string? Location { get; set; } //For owners refernece only eg. Back of cattle shed

    //Traceability
    public string MessageId { get; set; } = null!;

    public Source[] Transactions { get; set; } = null!;

    public string OwnerMsg { get; set; } = null!;

    //Default value
    public Batch()
    {
        InStock = true;
    }

}

public struct Source
{
    public string[] ProduceMsg;

    public string[]? TransactionMsg;

}