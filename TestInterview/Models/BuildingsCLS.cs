using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestInterview.Models
{
    public class BuildingsCLS
    {
        [Display(Name = "ID")]
        public int pkbuilding { get; set; }
        [Required]
        [Display(Name = "Building")]
        public string building { get; set; }
        [Required]
        [Display(Name = "Habilitado")]
        public bool avaliable { get; set; }

    }
}