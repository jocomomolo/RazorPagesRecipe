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
        public int SelectedOwnerID { get; set; }
        public List<SelectListItem> Owners { get; set; }

        [BindProperty]
        public int SelectedCategoryID { get; set; }
        public List<SelectListItem> Categories { get;set; }

        [BindProperty]
        public int[] SelectedUtensilsID { get; set; }
        public List<SelectListItem> Utensils { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            //Owners = await _context.Owner.OrderBy(a => a.OwnerID).Select(a => new SelectListItem { Value = a.OwnerID.ToString(), Text = a.Name }).ToListAsync();
            Categories = await _context.Category.OrderBy(a => a.CategoryID).Select(a => new SelectListItem {Value = a.CategoryID.ToString(), Text = a.Name }).ToListAsync();
            Utensils = await _context.Utensil.OrderBy(a => a.UtensilID).Select(a => new SelectListItem { Value = a.UtensilID.ToString(), Text = a.Name }).ToListAsync();

            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }
        public RecipeUtensil RecipeUtensil { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            RecipeUtensil = new RecipeUtensil();
            Recipe.CreationDate = DateTime.Today;
            Recipe.TotalTime = Recipe.PreparationTime + Recipe.CookingTime;
            //Pass Selected Category on View to Controller before Adding Recipe
            Recipe.Category = _context.Category.FirstOrDefault(c => c.CategoryID == SelectedCategoryID);
            //Recipe.Owner = _context.Owner.FirstOrDefault(c => c.OwnerID == SelectedOwnerID);

            _context.Recipe.Add(Recipe);
            _context.SaveChanges();

            foreach (var item in SelectedUtensilsID)
            {
                RecipeUtensil.RecipeID = Recipe.RecipeID;
                RecipeUtensil.UtensilID = item;
                _context.RecipeUtensil.Add(RecipeUtensil);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
