using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecipesWebApi.Models
{
    public record RecipeItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public IEnumerable<string> Directions { get; init; }
        public IEnumerable<string> Ingredients { get; init; }
        public DateTime Updated { get; init; }
    }
}
