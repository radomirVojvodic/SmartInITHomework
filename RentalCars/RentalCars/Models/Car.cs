using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalCars.Models;

namespace RentalCars.Models
{
    public class Car
    {

        public int ID { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }
        public int Year { get; set; }
    
    }
}