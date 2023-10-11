using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetRecipes()
        {
            string[] recipes = { "Oxtail", "Curry Chicken", "Dumplings" };
            
            if (!recipes.Any()) return NotFound();
            return Ok(recipes);
        }

        [HttpDelete]
        public ActionResult DeleteRecipes()
        {
            bool badThingsHappend = false;

            if(badThingsHappend) return BadRequest();
            
            return NoContent();
        }
    }
}
