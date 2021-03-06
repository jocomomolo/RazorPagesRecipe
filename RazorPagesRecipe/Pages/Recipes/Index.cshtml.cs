﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RazorPagesRecipe.Data;
using RazorPagesRecipe.Models;
using Syncfusion.EJ2.Base;
using Newtonsoft.Json.Serialization;
using Syncfusion.EJ2.Linq;

namespace RazorPagesRecipe.Pages.Recipes
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly RazorPagesRecipe.Data.RazorPagesRecipeContext _context;

        public IndexModel(RazorPagesRecipe.Data.RazorPagesRecipeContext context)
        {
            _context = context;
        }

        //public IList<Recipe> Recipe { get;set; }
        //public String[] prueba { get; set; } = { "nada", "tampoco" };
        //public async Task OnGetAsync()
        //{
        //    Recipe = await _context.Recipe.OrderBy(r => r.Category)
        //        .Include(recipe => recipe.Category)
        //        .ToListAsync();
        //}

        public JsonResult OnPostDataSource([FromBody] DataManagerRequest dm)
        {
            
            IQueryable query = _context.Recipe.OrderBy(r => r.Category)
            .Include(recipe => recipe.Category)
            .Select(x => new
                {
                    ID = x.RecipeID,
                    Category = x.Category.Name,
                    Title = x.Title,
                    TotalTime = x.TotalTime,
                    //Owner = x.Owner.Name,
                    Vegetarian = x.Vegetarian,
                    Freezable = x.Freezable,
                    Source = x.Source,
                    Ingredients = x.Ingredients, 
                });
            
            var DataSource = query;

            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = (IQueryable)operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = (IQueryable)operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = (IQueryable)operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Count();
            if (dm.Skip != 0)
            {
                DataSource = (IQueryable)operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = (IQueryable)operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new JsonResult(new { result = DataSource, count = count }) : new JsonResult(DataSource);
        }


    }
}
