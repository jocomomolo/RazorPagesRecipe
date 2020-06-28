using RazorPagesRecipe.Models.MasterClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models
{
    public class Owner : Master
    {
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
