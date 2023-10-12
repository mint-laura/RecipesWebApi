using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecipesWebApi.Models
{
    public record RecipeItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Directions { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public DateTime Updated { get; set; }
    }
}
