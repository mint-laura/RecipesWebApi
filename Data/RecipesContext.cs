using Microsoft.EntityFrameworkCore;

namespace RecipesWebApi.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options)
        {
        
        }
        
      
    }
}
