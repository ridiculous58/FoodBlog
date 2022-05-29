using MediatR;
using Microsoft.AspNetCore.Mvc;
using YemekTarifi.Application.Features.Queries.GetRecipeAll;
using YemekTarifi.Application.Features.Queries.GetRecipeById;

namespace YemekTarifi.MVC.Controllers;

public class RecipeController : Controller
{

    private readonly IMediator _mediator;
    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Recipes()
    {
        var recipes = await  _mediator.Send(new GetRecipeAllQuery());
        return View(recipes);
    }
    
    public async Task<IActionResult> RecipeDetail(string id)
    {
        var recipe = await  _mediator.Send(new GetRecipeByIdQuery(id));
        return View(recipe);
    }
    
}