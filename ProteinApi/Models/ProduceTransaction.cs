using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class ProduceTransaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProduceTransactionId { get; set; }

    public DateTime Date { get; set; }

    //Produce
    public string ProduceType { get; set; } = null!;

    public double Quantity { get; set; } //No.

    public double Weight { get; set; } //Kg

    public string BatchMsg { get; set; } = null!;

    public double? Price { get; set; } //£

    //Actors
    public string SenderId { get; set; } = null!;

    public string ReceiverId { get; set; } = null!;

    //IOTA message
    public string? MessageId { get; set; } = null!;


}
