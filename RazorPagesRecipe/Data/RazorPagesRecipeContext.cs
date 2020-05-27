using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesRecipe.Models;

namespace RazorPagesRecipe.Data
{
    public class RazorPagesRecipeContext : DbContext
    {
        public RazorPagesRecipeContext (DbContextOptions<RazorPagesRecipeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeUtensil>().HasKey(sc => new { sc.RecipeID, sc.UtensilID });
        } 
        public DbSet<RazorPagesRecipe.Models.Recipe> Recipe { get; set; }
        public DbSet<RazorPagesRecipe.Models.Ingredient> Ingredient { get; set; }
        public DbSet<RazorPagesRecipe.Models.RecipeUtensil> RecipeUtensil { get; set; }
        public DbSet<RazorPagesRecipe.Models.Category> Category { get; set; }
    }
}
