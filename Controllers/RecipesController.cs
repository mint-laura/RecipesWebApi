using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Models;
using RecipesWebApi.Services;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService) => _recipeService = recipeService;

        [HttpGet("GetRecipe/{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var existingRecipie = await _recipeService.GetRecipeAsync(id);

            if (existingRecipie is null)
                return NotFound();

            return Ok(existingRecipie);
        }

        [HttpGet("GetRecipes")]
        public async Task<IActionResult> Get()
        {
            var allRecipes = await _recipeService.GetRecipesAsync();

            if (allRecipes.Any())
                return Ok(allRecipes);

            return NotFound();
        }

        [HttpPost("CreateRecipe")]
        public async Task<IActionResult> Post(RecipeItem recipe) 
        {
            await _recipeService.CreateRecipeAsync(recipe);
            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }

        [HttpPut("EditRecipe/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, RecipeItem recipe)
        {
            var existingRecipe = await _recipeService.GetRecipeAsync(id);

            if (existingRecipe is null)
                return BadRequest();

            recipe.Id = existingRecipe.Id;

            await _recipeService.UpdateRecipeAsync(recipe);

            return NoContent();
        }

        [HttpDelete("DeleteRecipe/{id:length(24)}")]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            var existingRecipe = await _recipeService.GetRecipeAsync(id);

            if (existingRecipe is null)
                return BadRequest();

            await _recipeService.RemoveRecipeAsync(id);

            return NoContent();
        }
    }
}
