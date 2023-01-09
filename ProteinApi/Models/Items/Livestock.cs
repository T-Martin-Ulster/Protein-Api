using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Animal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AnimalId { get; set; }









    //IOTA message
    public string? MessageId { get; set; } = null!;

}
