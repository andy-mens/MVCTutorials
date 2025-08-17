using Microsoft.AspNetCore.Mvc;
using MVCTutorials.Models;
using System;


namespace MVCTutorials.Controllers
{
    public class DatabaseCollectionsController : Controller
    {
        private readonly ItemService _itemService;

        public DatabaseCollectionsController(ItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult Create()
        {
            // This action method is intentionally left empty.
            // It can be used to display a list of database collections in the future.
            return View();
        }

        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var items = await _itemService.GetAsync();
                return Json(new {success = true, _items = items});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { success = false, message = "Error retrieving items!" });

            }
        }

        [HttpPost]
        public IActionResult AddToDb(string Name, string Description, decimal Price)
        {
            // This action method is intentionally left empty.
            // It can be used to handle the creation of a new database collection in the future.
            if (Name != null && Description != null && Price >= 0) {
                Item item = new Item(Guid.NewGuid().ToString(), Name, Description, Price);
                try
                {
                    _itemService.Create(item);
                    return Json(new { success = true, message = $"Item {Name} with price {Price} and description {Description} added successfully!" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Json(new { success = false, message = "Item not added!" });
                }

            }

            return Json(new { success = false, message = "Invalid input!" });

            //return RedirectToAction("Create", "DatabaseCollections");

        }
    }
}
