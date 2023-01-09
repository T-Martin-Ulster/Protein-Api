using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProteinApi.Structs;

namespace ProteinApi.Models;

public class Produce
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProduceId { get; set; }

    //Produce
    public string? Seed { get; set; } //batch Id of seed

    public double QuantityPlanted { get; set; } //Kg

    public string ProduceClass { get; set; } = null!; //Vegetables

    public string ProduceType { get; set; } = null!; //Potatoes

    public string? ProduceVarity { get; set; } //Lady roseta

    //Farming
    public string? FarmId { get; set; }

    public string? FarmMsg { get; set; }

    public string? FieldId { get; set; }

    public string? FieldMsg { get; set; }

    public DateOnly? PlantDate { get; set; }

    public DateOnly? HarvestDate { get; set; }

    //todo STANDARDS

    //IOTA message
    public string? MessageId { get; set; } = null!;


}
