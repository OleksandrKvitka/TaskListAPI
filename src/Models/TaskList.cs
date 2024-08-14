using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace TaskListAPI.Models
{
	public class TaskList
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("ownerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string OwnerId { get; set; }

        [BsonElement("tasks")]
        public List<string> Tasks { get; set; } = [];

        [BsonElement("sharedWithUsers")]
        public List<string> SharedWithUsers { get; set; } = [];

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

