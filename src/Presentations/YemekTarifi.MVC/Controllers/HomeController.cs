using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifi.Application.Features.Queries.GetRecipeAll;

namespace YemekTarifi.MVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _mediator.Send(new GetRecipeAllQuery(true));
            return View(recipes);
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
        public IActionResult Error()
        {
            return View();
        }
    }
}
