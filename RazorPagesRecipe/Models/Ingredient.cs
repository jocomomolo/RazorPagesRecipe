using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        //Name contains Name + Quantity for Input simplicity
        public string Name { get; set; }
        //public string Quantity { get; set; }
        public Recipe Recipe { get; set; }

    }
}