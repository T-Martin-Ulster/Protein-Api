using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Field
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? FieldId { get; set; }

    public string OwnerId { get; set; } = null!;

    public double Size { get; set; }

    public string? GpsCoordinates { get; set; }

    //todo FERTILIZER

    //IOTA message
    public string? MessageId { get; set; } = null!;

}
