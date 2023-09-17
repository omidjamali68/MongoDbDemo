using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  MongoDbDemo.Models;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; }
}