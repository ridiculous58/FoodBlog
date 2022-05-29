using MediatR;
using YemekTarifi.Application.Dtos;

namespace YemekTarifi.Application.Features.Commands.CreateRecipe;

public class CreateRecipeCommand : IRequest<bool>
{
    public RecipeDto RecipeDto { get; set; }

    public CreateRecipeCommand(RecipeDto recipeDto)
    {
        RecipeDto = recipeDto;
    }
}