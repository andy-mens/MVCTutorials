using Microsoft.AspNetCore.Mvc;
using MVCTutorials.Models;

namespace MVCTutorials.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item(1, "Sample Item", "This is a sample item description.", 19.99m);
            return View(item);
        }

        public IActionResult Details() { 
           var item = new Item(2, "Detailed Item", "Key: Value", 29.99m);
           return Json(item.Description);
        }

        public IActionResult Create(int id, string name, string description, decimal price)
        {
            var item = new Item(id, name, description, price);
            return Json(item);
        }
    }
}
