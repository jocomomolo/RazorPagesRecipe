using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class RecipeUtensil
    {
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        public int UtensilID { get; set; }
        public Utensil Utensil { get; set; }
    }
}
