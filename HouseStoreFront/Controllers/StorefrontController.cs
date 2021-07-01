using HouseStoreFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        [HttpPost]
        public IActionResult Buy(House h)
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
