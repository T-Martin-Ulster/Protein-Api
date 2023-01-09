using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Business
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BusinessId { get; set; }

    public string UserId { get; set; } = null!;

    public string BusinessType { get; set; } = null!; //Farm, Bakery, Distribution Centre

    public string GpsCoordinates { get; set; } = null!;

    //IOTA message
    public string? MessageId { get; set; } = null!;

}
