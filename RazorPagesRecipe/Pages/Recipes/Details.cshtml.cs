using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecipe.Data;
using RazorPagesRecipe.Models;

namespace RazorPagesRecipe.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public DetailsModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }
       
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredients => recipeIngredients.Ingredient)
                .Include(recipe => recipe.RecipeUtensils)
                    .ThenInclude(recipeUtensils => recipeUtensils.Utensil)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
