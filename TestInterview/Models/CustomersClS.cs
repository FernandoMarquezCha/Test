using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestInterview.Models
{
    public class CustomersClS
    {
        [Display(Name = "ID")]
        public int pkcustomers { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public string customer { get; set; }
        [Required]
        [Display(Name = "Prefix")]
        public string prefix { get; set; }
        [Display(Name = "Building")]
        public int building { get; set; }
        [Display(Name = "Avaliable")]
        public bool avaliable { get; set; }
        
        public string buildingname { get; set; }
    }
}