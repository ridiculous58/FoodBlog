using AutoMapper;
using MediatR;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Commands.UpdateRecipe;

public class UpdateRecipeCommand : IRequest<bool>
{
    public UpdateRecipeCommand(RecipeViewModel recipeViewModel)
    {
        RecipeViewModel = recipeViewModel;
    }
    public RecipeViewModel RecipeViewModel { get; set; }
}

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand,bool>
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;
    public UpdateRecipeCommandHandler(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _mapper.Map<RecipeViewModel, Recipe>(request.RecipeViewModel);
        await _recipeService.UpdateAsync(recipe);
        return true;
    }
}