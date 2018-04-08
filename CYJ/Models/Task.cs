using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYJ.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskText { get; set; }
        public string Status { get; set; }
    }
}