using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class ProduceTransaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionId { get; set; }

    public DateTime Date { get; set; }

    public bool Confirmed { get; set; }

    public double Quantity { get; set; } //Kg

    public double? Price { get; set; } //£

    public string BatchMsg { get; set; } = null!;

    //Actors
    public string SenderId { get; set; } = null!; 

    public string ReceiverId { get; set; } = null!; //Id OR Unknown, QR code can be used to accept unknown transctions.

    //IOTA message
    public string? MessageId { get; set; } = null!; //Only when confirmed does it get a message id -- maybe?


}
