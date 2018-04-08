using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYJ.Models.ViewModels
{
    public class GoalCatViewModel
    {
        public List<SelectListItem> GOALCAT { get; set; }
        public string goalName { get; set; }
        public int goalID { get; set; }

        public GoalCatViewModel()
        {
            this.GOALCAT = new List<SelectListItem>();
        }
    }
}