using Microsoft.AspNetCore.Mvc;

namespace Ventas_MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}
    }
}
