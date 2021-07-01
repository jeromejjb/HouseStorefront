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
            List<House> houses = db.Houses.ToList();
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


            return RedirectToAction("Index", "House");
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
            return RedirectToAction("Index", "House");
        }

        public IActionResult Delete(int Id)
        {
            House h = db.Houses.Find(Id);
            return View(h);
        }

        [HttpPost]
        public IActionResult Delete(House h)
        {
            // Movie m = db.Movies.Find(Id);
            db.Houses.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index", "House");
        }
    }
}
