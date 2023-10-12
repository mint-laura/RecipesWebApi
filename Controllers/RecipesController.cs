using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Models;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetRecipes([FromQuery]int count)
        {
            RecipeItem[] recipes = { 
                new() { Title = "Oxtail" },
                new() { Title = "Curry Chicken" },
                new() { Title = "Dumplings" }
            };
            
            return Ok(recipes.Take(count));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipes(string id)
        {
            bool badThingsHappend = false;

            if(badThingsHappend) return BadRequest();
            
            return NoContent();
        }
    }
}
