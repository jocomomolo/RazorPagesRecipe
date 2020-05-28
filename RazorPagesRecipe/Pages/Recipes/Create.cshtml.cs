using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecipe.Data;
using RazorPagesRecipe.Models;

namespace RazorPagesRecipe.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public CreateModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int SelectedCategoryID { get; set; }
        public List<SelectListItem> Categories { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Category.Select(a => new SelectListItem {Value = a.CategoryID.ToString(), Text = a.Name }).ToListAsync();
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IList<Ingredient> Ingredients { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var item in Ingredients)
            {
                item.Recipe = Recipe;
            }
            
            //Pass Selected Category on View to Controller before Adding Recipe
            Recipe.Category = _context.Category.FirstOrDefault(c => c.CategoryID == SelectedCategoryID);

            _context.Recipe.Add(Recipe);

            foreach (var item in Ingredients)
                {
                    _context.Ingredient.Add(item);
                }
            //_context.Ingredient.Add(Ingredient);


            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
