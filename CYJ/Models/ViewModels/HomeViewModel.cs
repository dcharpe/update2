using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<SelectListItem> ABOUT { get; set; }
        public List<SelectListItem> QUARTERLYUPDATE { get; set; }
        public int aboutID { get; set; }
        [Display(Name = "Post Header")]
        public string aboutHeader { get; set; }
        [Display(Name = "Post Body")]
        public string aboutBody { get; set; }
        public int updateID { get; set; }
        [Display(Name = "Update Header")]
        public string updateHeader { get; set; }
        [Display(Name = "Update Body")]
        public string updateBody { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> updateDate { get; set; }

        public HomeViewModel()
        {
            this.ABOUT = new List<SelectListItem>();
            this.QUARTERLYUPDATE = new List<SelectListItem>();
        }
    }
}