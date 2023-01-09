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
    public bool Mixed { get; set; }

    public string ProduceType { get; set; } = null!;

    public double Quantity { get; set; } //No.

    public double Weight { get; set; } //Kg


    public string? ProduceMsg { get; set; } //Not-Mixed

    public string[]? BatchMsg { get; set; } //Mixed


    //Traceability
    public string MessageId { get; set; } = null!;

    public string? TransactionMsg { get; set; }


    //Default value
    public Batch()
    {
        InStock = true;
    }

}
