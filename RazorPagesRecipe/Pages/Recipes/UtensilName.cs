using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RazorPagesRecipe.Data;

namespace RazorPagesRecipe.Pages.Recipes
{
    public class UtensilNamePageModel : PageModel
    {
        public SelectList UtensilNameSL { get; set; }

        public void PopulateUtensilsDropDownList(RazorPagesRecipeContext _context,
            object selectedUtensil = null)
        {
            var utensilsQuery = from u in _context.Utensil
                                    orderby u.Name // Sort by name.
                                    select u;

            UtensilNameSL = new SelectList(utensilsQuery.AsNoTracking(),
                        "UtensilID", "Name", selectedUtensil);
        }
    }

}
