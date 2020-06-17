using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RazorPagesRecipe.Data;
using RazorPagesRecipe.Models;

namespace RazorPagesRecipe.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public IndexModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }
        public Recipe Recetas { get; set; }
        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe.OrderBy(r => r.Category)
                .Include(recipe => recipe.Category)
                .ToListAsync();
            Recetas = _context.Recipe.FirstOrDefault();
        }

    }
}
