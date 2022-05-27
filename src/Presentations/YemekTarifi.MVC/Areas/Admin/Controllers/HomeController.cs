using Microsoft.AspNetCore.Mvc;

namespace YemekTarifi.MVC.Areas.Admin.Controllers
{

    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Eat()
        {
            return View();
        }


    }
}
