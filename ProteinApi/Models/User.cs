using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProteinApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = null!;

    public string UserType { get; set; } = null!; //Farm, Bakery, Distribution Centre

    public string UserName { get; set; } = null!;

    public string? Address { get; set; }

    public Tag[]? Info { get; set; }

}
