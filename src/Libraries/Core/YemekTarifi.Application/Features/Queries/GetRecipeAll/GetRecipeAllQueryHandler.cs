using AutoMapper;
using MediatR;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Queries.GetRecipeAll;

public class GetRecipeAllQueryHandler : IRequestHandler<GetRecipeAllQuery,IEnumerable<RecipeViewModel>>
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;
    
    public GetRecipeAllQueryHandler(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RecipeViewModel>> Handle(GetRecipeAllQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _recipeService.GetRecipeAllAsync();
        
        return _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);
    }
}