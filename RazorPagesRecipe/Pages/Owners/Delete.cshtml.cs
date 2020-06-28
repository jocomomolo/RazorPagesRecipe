using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecipe.Data;
using RazorPagesRecipe.Models;

namespace RazorPagesRecipe.Pages.Owners
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public DeleteModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner = await _context.Owner.FirstOrDefaultAsync(m => m.OwnerID == id);

            if (Owner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner = await _context.Owner.FindAsync(id);

            if (Owner != null)
            {
                _context.Owner.Remove(Owner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
