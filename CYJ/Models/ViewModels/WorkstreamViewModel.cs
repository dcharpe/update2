using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYJ.Models.ViewModels
{
    public class WorkstreamViewModel
    {
        public List<SelectListItem> WORKSTREAM { get; set; }
        public string workstreamName { get; set; }
        public int workstreamID { get; set; }

        public WorkstreamViewModel()
        {
            this.WORKSTREAM = new List<SelectListItem>();
        }
    }
}