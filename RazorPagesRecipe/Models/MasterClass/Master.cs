using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesRecipe.Models.MasterClass
{
    public class Master
    {
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
