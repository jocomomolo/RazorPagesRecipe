using RazorPagesRecipe.Models.MasterClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Recipe : Master
    {
        public int RecipeID { get; set; }
        [Required]
        public string Title { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Portions { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Source { get; set; }
        
        [Required]
        public Boolean Freezable { get; set; }
        //Times in minutes
        public int? TotalTime { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? PreparationTime { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? CookingTime { get; set; }

        //One recipe has one category: Snack/Main/Dessert
        public Category Category { get; set; }
        //One recipe has one Owner
        public Owner Owner { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public Boolean Vegetarian { get; set; }
        public IList<RecipeUtensil> RecipeUtensils { get; set; }
    }
}
