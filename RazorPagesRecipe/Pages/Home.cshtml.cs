using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Extensions.Logging;

namespace RazorPagesRecipe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Input Date for Calendar
        public DateTime? Date { get; set; } = new DateTime();
        //Default value for DropDown List
        public String Game { get; set; } = "American Football";

        public String[] GamesData { get; set; } = { "Tennis, Football" };

        public void OnGet()
        {

        }
    }
}
