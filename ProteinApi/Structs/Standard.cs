using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Produce
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProduceId { get; set; }

    public string ProduceClass { get; set; } = null!; //vegetables

    public string ProduceType { get; set; } = null!; //Potatoes

    public string? ProduceVarity { get; set; } //Lady roseta






    //IOTA message
    public string? MessageId { get; set; } = null!;

}
