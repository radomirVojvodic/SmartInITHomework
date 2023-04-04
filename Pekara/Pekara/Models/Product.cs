using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pekara.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyy}", ApplyFormatInEditMode = false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyy}", ApplyFormatInEditMode = false)]
        public DateTime ExpirationDate { get; set; }

        
    }
}