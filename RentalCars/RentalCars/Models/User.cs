using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalCars.Models;

namespace RentalCars.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }

    }
}