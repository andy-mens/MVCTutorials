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

        //public IActionResult add(string customerName, string item)
        //{
            

        //}
    }
}
