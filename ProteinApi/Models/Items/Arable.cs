using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Vegetable
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? VegetableId { get; set; }









    //IOTA message
    public string? MessageId { get; set; } = null!;

}
