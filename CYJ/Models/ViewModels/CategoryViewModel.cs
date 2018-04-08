using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYJ.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<SelectListItem> CATEGORY { get; set; }
        public string categoryName { get; set; }
        public int categoryID { get; set; }

        public CategoryViewModel()
        {
            this.CATEGORY = new List<SelectListItem>();
        }
    }
}