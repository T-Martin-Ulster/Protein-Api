using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Livestock
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? LivestockId { get; set; }

    public string? Name { get; set; }

    public string? Tag { get; set; }

    public string LivestockType { get; set; } = null!; //Cattle, Sheep etc

    public string Breed { get; set; } = null!; //Angus, Wagu, Dexter OR Unknown

    public string Gender { get; set; } = null!;

    public string? DOB { get; set; } // DD/MM/YYYY

    public double? Weight { get; set; } //Kg

    public string? MotherId { get; set; }

    public string? MotherMsgId { get; set; }

    //MEDICAL HISTORY

    //STANDARDS - Pasture for life

    //IOTA message
    public string? MessageId { get; set; } = null!;

}
