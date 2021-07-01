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


        public IActionResult Details(int id)
        {
            House h = db.Houses.Find(id);
            return View(h);
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


            return RedirectToAction("Index", "Product");
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
            return RedirectToAction("Index", "Product");
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
            return RedirectToAction("Index", "Product");
        }
    }
}
