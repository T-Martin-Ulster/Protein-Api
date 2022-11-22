using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Transaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionId { get; set; }

    //Trasaction & Productdetails
    public string TransactionType { get; set; } = null!; //Sending OR Using as ingredient

    public string ProductId { get; set; } = null!;

    public double Quantity { get; set; }

    //Time and location of transaction
    public DateTime Date { get; set; }

    public string? GpsCoordinates { get; set;}

    //Actors
    public string SenderId { get; set; } = null!;

    public string? ReceiverId { get; set; }

    //IOTA message
    public string? MessageId { get; set; }

}
