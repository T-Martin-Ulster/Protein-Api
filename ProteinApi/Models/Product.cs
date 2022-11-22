using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Transaction
{
    //Trasaction details
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionID { get; set; }

    public int MessageID { get; set; }

    public int TransactionType { get; set; }

    public int ProductID { get; set; }

    public double Quantity { get; set; } 
    

    //Time and location of transaction
    public DateTime Date { get; set; }

    public string? GpsCoordinates { get; set;}
    
}
