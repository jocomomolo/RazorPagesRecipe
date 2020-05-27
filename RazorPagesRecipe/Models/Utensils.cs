using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Utensil
    {
        public int UtensilID { get; set; }
        public string Name { get; set; }

        public IList<RecipeUtensil> RecipeUtensils { get; set; }
    }
}
