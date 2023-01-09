using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class Business
{
    [BsonId]
    public string BusinessId { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string BusinessType { get; set; } = null!; //Farm, Bakery, Distribution Centre

    public string Name { get; set; } = null!;

    public string Decription { get; set; } = null!;

    public string GpsCoordinates { get; set; } = null!;

    //todo STANDARDS

    //IOTA message
    public string? MessageId { get; set; } = null!;
}
