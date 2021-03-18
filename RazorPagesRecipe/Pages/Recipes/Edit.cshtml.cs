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
    public class EditModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public EditModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public int? SelectedOwnerID { get; set; }

        [BindProperty]
        public string OwnerName { get; set; }
        public List<SelectListItem> Owners { get; set; }
        [BindProperty]
        public int? SelectedCategoryID { get; set; }

        [BindProperty]
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }

        [BindProperty]
        public int[] SelectedUtensilsID { get; set; }
        public List<SelectListItem> Utensils { get; set; }
        public IList<Utensil> AllUtensils { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe
                .Include(recipe => recipe.Category)
                //.Include(recipe => recipe.Owner)
                .Include(recipe => recipe.RecipeUtensils)
                    .ThenInclude(recipeUtensils => recipeUtensils.Utensil)
            .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }

            //SelectedOwnerID = Recipe.Owner.OwnerID;
            //OwnerName = Recipe.Owner.Name;
            //Owners = await _context.Owner.Select(a => new SelectListItem { Value = a.OwnerID.ToString(), Text = a.Name }).ToListAsync();
            SelectedCategoryID = Recipe.Category.CategoryID;
            CategoryName = Recipe.Category.Name;
            Categories = await _context.Category/*.Where(c => c.CategoryID != Recipe.Category.CategoryID)*/.Select(a => new SelectListItem { Value = a.CategoryID.ToString(), Text = a.Name }).ToListAsync();
            //Many Ingredients but whatever, lets input all in one entity and separate by line breaks like Description
            Utensils = await _context.Utensil.Select(a => new SelectListItem { Value = a.UtensilID.ToString(), Text = a.Name }).ToListAsync();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Recipe.TotalTime = Recipe.PreparationTime + Recipe.CookingTime;
            //Pass Selected Category on View to Controller before Adding 
            //Recipe.Owner = _context.Owner.FirstOrDefault(c => c.OwnerID == SelectedOwnerID);
            Recipe.Category = _context.Category.FirstOrDefault(c => c.CategoryID == SelectedCategoryID);
            _context.Attach(Recipe).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.RecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeID == id);
        }
    }
}
