using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalCars.Models;

namespace RentalCars.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var users = GetUsers();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var users = GetUsers();
            var user = users.SingleOrDefault(c => c.ID == id);
            if (user == null)
            {

                return HttpNotFound();
            }
            //else
            //{
            return View(user);
            //}
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User {ID= 1, FirstName ="Radomir", LastName="Vojvodic", Year=1997},
                new User {ID= 2, FirstName ="Nina", LastName="Vojvodic", Year=1998},
                new User {ID= 3, FirstName ="Bojan", LastName="Raskovic", Year=1998}

            };
        }
    }
}