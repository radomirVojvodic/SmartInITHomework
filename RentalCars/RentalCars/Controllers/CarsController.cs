using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalCars.Models;

namespace RentalCars.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            var cars = GetCars();
            return View(cars);
        }

        private IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>
            {
                new Car{ID=1,Manufacture="Audi", Model="A6", Year=2010},
                new Car{ID=2, Manufacture="BMW", Model="X5", Year=2018},
                new Car{ID=3, Manufacture="Hyndai", Model="i30", Year=2023}
            };

            return cars;
        }


    }
}