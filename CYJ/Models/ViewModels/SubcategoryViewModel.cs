using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYJ.Models.ViewModels
{
    public class SubcategoryViewModel
    {
        public List<SelectListItem> SUBCATEGORY { get; set; }
        public string subcategoryName { get; set; }
        public int subcategoryID { get; set; }

        public SubcategoryViewModel()
        {
            this.SUBCATEGORY = new List<SelectListItem>();
        }
    }
}