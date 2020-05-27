using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }

        public string Quantity { get; set; }
        public IList<RecipeIngredient> RecipeIngredients { get; set; }
        
    }
}