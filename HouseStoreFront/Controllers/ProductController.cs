using HouseStoreFront.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseStoreFront.Controllers
{
    public class ProductController : Controller
    {

        HousesDbContext db = new HousesDbContext();

    public IActionResult Index()
        {
            List<House> houses = db.Houses.Where(x => x.Quantity ==1).ToList();
            return View(houses);
        }

    public IActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHouse(House h)
        {
            db.Houses.Add(h);
            db.SaveChanges();


            return RedirectToAction("Storefront", "Product");
        }

        public IActionResult Update(int id)
        {
            House h = db.Houses.Find(id);
            return View(h);
        }

        [HttpPost]
        public IActionResult Update(House h)
        {
            db.Houses.Update(h);
            db.SaveChanges();
            return RedirectToAction("Storefront", "Product");
        }

        public IActionResult Delete(int Id)
        {
            House h = db.Houses.Find(Id);
            return View(h);
        }

        [HttpPost]
        public IActionResult Delete(House h)
        {
           
            db.Houses.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Storefront", "Product");
        }
    }
}
