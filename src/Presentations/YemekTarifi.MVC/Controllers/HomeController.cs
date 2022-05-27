using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekTarifi.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }

        public IActionResult RecipeDetail()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
