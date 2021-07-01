using HouseStoreFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HouseStoreFront.Models;

namespace HouseStoreFront.Controllers
{
    public class HomeController : Controller
    {

        HousesDbContext db = new HousesDbContext();
      

        public IActionResult Index()
        {
            List<House> h = db.Houses.ToList();
            return View(h);
        }

        public IActionResult Buy(int id)
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
