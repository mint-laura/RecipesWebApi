using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecipesWebApi.Config;
using RecipesWebApi.Models;

namespace RecipesWebApi.Services
{
    public class RecipeService
    {
        private readonly IMongoCollection<RecipeItem> _recipeCollection;

        public RecipeService(IOptions<DbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _recipeCollection = mongoDb.GetCollection<RecipeItem>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<RecipeItem>> GetRecipesAsync() =>
            await _recipeCollection.Find(_ => true).ToListAsync();

        public async Task<RecipeItem> GetRecipeAsync(string id) =>
            await _recipeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateRecipeAsync(RecipeItem recipe) => 
            await _recipeCollection.InsertOneAsync(recipe);

        public async Task UpdateRecipeAsync(RecipeItem recipe) => 
            await _recipeCollection.ReplaceOneAsync(x => x.Id == recipe.Id, recipe);

        public async Task RemoveRecipeAsync(string id) =>
            await _recipeCollection.DeleteOneAsync(x => x.Id == id);
    }
}
