using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProductId { get; set; }

    public string ProductName { get; set; } = null!; //Weetabix

    public string ProductType { get; set; } = null!; //Cereal

    public Batch[]? Ingredients { get; set; }

    public string ProducerId { get; set; } = null!;

    //Standards

    //BusinessInfo

    //Time and location of creation
    public DateTime Date { get; set; }

    public string? FieldId { get; set;}

    //IOTA message
    public string? MessageId { get; set; } = null!;

    public string BusinessMessageId { get; set; } = null!;

    public string FieldMessageId { get; set; } = null!;

}
