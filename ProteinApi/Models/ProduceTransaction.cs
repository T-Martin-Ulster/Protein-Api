using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Transaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionId { get; set; }

    public DateTime Date { get; set; }

    
    
    //Actors
    public string SenderId { get; set; } = null!;

    public string SenderMsgId { get; set; } = null!;

    public string ReceiverId { get; set; } = null!; //Id OR Unknown

    public string? ReceiverMsgId { get; set; }

    //IOTA messages
    public string? MessageId { get; set; } = null!;

}
