using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace YourSay.Models
{
    public class Causes
    {
        [Key]
        public int CauseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        public string Category { get; set; }
        public int Counter { get; set; }
        public string Supporter { get; set; } = "";         //Instanciated as ""
        public List<string> Supporters { get; set; }        //To be used only for the table heads
    }
}