using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductId { get; set; } = null!;

    //Product details
    public string OwnerId { get; set; } = null!;

    public string ProductName { get; set; } = null!; //Weetabix

    public string ProductType { get; set; } = null!; //Cereal

    public double Quantity { get; set; } 

    public string QuanityType { get; set; } = null!; //No OR Kg

    public Ingredient[]? Ingredients { get; set; } //Array of ProductIds & Quantitys

    public bool Status { get; set; } //Active?

    public Tag[]? Info { get; set; }

    public string? TransactionId { get; set; } //Source

    //Time and location of creation
    public DateTime Date { get; set; }

    public string? GpsCoordinates { get; set;}

    //IOTA message
    public string MessageId { get; set; } = null!; //Orgional, defined during product creation
    
}
