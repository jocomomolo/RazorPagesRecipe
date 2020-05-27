using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Source { get; set; }
        public string Owner { get; set; }
        //Times in minutes
        public int? TotalTime { get; set; }
        public int? PreparationTime { get; set; }
        public int? CookingTime { get; set; }
        //One recipe has one category: Snack/Main/Dessert
        public Category Category { get; set; }
        public IList<RecipeIngredient> RecipeIngredients { get; set; }
        public IList<RecipeUtensil> RecipeUtensils { get; set; }
    }
}
