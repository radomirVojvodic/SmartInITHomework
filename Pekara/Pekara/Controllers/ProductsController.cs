using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pekara.Models;
using System.Net;

namespace Pekara.Controllers
{
    public class ProductsController : Controller
    {
        
        // GET: Products
        public ActionResult Index()
        {
            var products = GetProducts();

            if (products != null)
            {
                return View(products);
            }
            return HttpNotFound();
        }


        //GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var products = GetProducts();
            var product = products.SingleOrDefault(c => c.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,ProductID,Description,,Price,CreationDate,ExpirationDate")] Product redefProduct)
        {
            if (ModelState.IsValid)
            {
                List<Product> productList = GetProducts();

                // sa SingleOrDefault-om pravi problem, sa FirstOrDefault radi zavrseno
                Product product = productList.SingleOrDefault(c => c.ProductID == redefProduct.ProductID);
                productList.Remove(product);
                productList.Add(redefProduct);
                RefreshList(productList);
                return RedirectToAction("Index");

            }


            return View(redefProduct);
        }


        //GET: Products/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = GetProducts().FirstOrDefault(c => c.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Product> productList = GetProducts();
            Product product = productList.SingleOrDefault(c => c.ProductID == id);
            productList.Remove(product);
            RefreshList(productList);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var products = GetProducts();
            var product = products.SingleOrDefault(c => c.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        private List<Product> GetProducts()
        {
            // sa SingleOrDefault-om pravi problem, sa FirstOrDefault isto pravi problem - smisliti kako da uzimi unique IDjeve
            string filePath = Server.MapPath(@"~/App_Data/Products.json");
            string jsonFromFile = System.IO.File.ReadAllText(filePath);
            List<Product> listOfProducts = JsonConvert.DeserializeObject<List<Product>>(jsonFromFile);

            return listOfProducts;
        }

        private void AddProduct(Product product)
        {
            var products = GetProducts();
            product.ProductID = products.Count();
            products.Add(product);

            string jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

            string filePath = Server.MapPath(@"~/App_Data/Products.json");
            System.IO.File.WriteAllText(filePath, jsonString);
        }

        public void RefreshList(List<Product> productList)
        {
            System.IO.File.WriteAllText(Server.MapPath(@"~/App_Data/Products.json"), "");
            string jsonToFile = JsonConvert.SerializeObject(productList, Formatting.Indented);
            System.IO.File.WriteAllText(Server.MapPath(@"~/App_Data/Products.json"), jsonToFile);
        }
    }
}