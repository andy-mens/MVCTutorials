using Microsoft.AspNetCore.Mvc;

namespace MVCTutorials.Controllers
{
    public class SalesRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            // This action method is intentionally left empty.
            // It can be used to handle checkout logic in the future.
            return View();
        }

        public IActionResult validateCustomerAndProduct(string customerName, string item)
        {
            // This action method is intentionally left empty.
            // It can be used to display details of a specific sales register entry in the future.
            return View();
        }
    }
}
