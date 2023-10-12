using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Models;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet("GetRecipes")]
        public ActionResult GetRecipes([FromQuery]int count)
        {
            RecipeItem[] recipes = { 
                new() { Title = "Oxtail" },
                new() { Title = "Curry Chicken" },
                new() { Title = "Dumplings" }
            };
            
            return Ok(recipes.Take(count));
        }

        [HttpPost("CreateRecipe")]
        public ActionResult CreateRecipe([FromBody]RecipeItem NewRecipe) 
        {
            //Validate and save to database
            bool badThingsHappend = false;

            if (badThingsHappend) return BadRequest();

            return Created("", NewRecipe);
        }

        [HttpDelete("DeleteRecipe/{id}")]
        public ActionResult DeleteRecipe(string id)
        {
            bool badThingsHappend = false;

            if(badThingsHappend) return BadRequest();
            
            return NoContent();
        }
    }
}
