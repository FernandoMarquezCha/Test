using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestInterview.Models
{
    public class PartNumbersCLS
    {
        [Display(Name = "ID")]
        public int pkpartnumber { get; set; }
        [Required]
        [Display(Name = "PartNumber")]
        public string partnumber { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int customer { get; set; }
        [Display(Name = "Avaliable")]
        public bool avaliable { get; set; }
        public string customername { get; set; }

     
    }
}