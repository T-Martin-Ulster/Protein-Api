using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class TransactionRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionRequestId { get; set; } //QR code links to request

    public string ProduceType { get; set; } = null!;

    public double Quantity { get; set; } //No.

    public double Weight { get; set; } //Kg

    public string BatchMsg { get; set; } = null!;

    public double? Price { get; set; } //£

    //Actors
    public string SenderId { get; set; } = null!;

}
