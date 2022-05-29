using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YemekTarifi.Application.Dtos;
using YemekTarifi.Application.Features.Commands.CreateRecipe;
using YemekTarifi.Application.Features.Commands.DeleteRecipeById;
using YemekTarifi.Application.Features.Commands.UpdateRecipe;
using YemekTarifi.Application.Features.Queries.GetRecipeAll;
using YemekTarifi.Application.Features.Queries.GetRecipeById;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.MVC.Areas.Admin.Controllers
{

    public class HomeController : BaseAdminController
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Recipe()
        {
            var recipes = await _mediator.Send(new GetRecipeAllQuery());
            return View(recipes);
        }
        [HttpGet]
        public async Task<IActionResult> RecipeEdit(string id)
        {
            var recipes = await _mediator.Send(new GetRecipeByIdQuery(id));
            return View(recipes);
        }
        [HttpPost]
        public async Task<IActionResult> RecipeEdit(RecipeViewModel recipe)
        {
            await _mediator.Send(new UpdateRecipeCommand(recipe));
            return RedirectToAction("Recipe","Home");
        }
        [HttpGet]
        public async Task<IActionResult> RecipeAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RecipeAdd(RecipeDto recipeDto)
        {
            await _mediator.Send(new CreateRecipeCommand(recipeDto));
            return RedirectToAction("Recipe","Home");
        }
        public async Task<IActionResult> RecipeDelete(string id)
        {
            await _mediator.Send(new DeleteRecipeByIdCommand(id));
            return RedirectToAction("Recipe");
        }
        
        public async Task<IActionResult> Profile()
        {
            return View(await _userManager.GetUserAsync(HttpContext.User));
        }
        
        


    }
}
