using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  MongoDbDemo.Models;

public class Category
{
    [BsonId]
    public string Id { get; set; }
    public string Title { get; set; }
}