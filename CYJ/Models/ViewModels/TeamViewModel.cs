using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYJ.Models.ViewModels
{
    public class TeamViewModel
    {
        public List<SelectListItem> TEAMS { get; set; }
        public string teamName { get; set; }
        public int teamID { get; set; }

        public TeamViewModel()
        {
            this.TEAMS = new List<SelectListItem>();
        }
    }
}