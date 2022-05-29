using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        IQueryable<Recipe> table = _recipeService.Table;

        table = table.Include(x => x.RecipeCategory); // eagle loading
        
        if (request.IsOrderByDescendingForCreatedDate)
        {
            table = table.OrderByDescending(x => x.CreatedDate);
        }

        var recipes = await Task.Run(() => table.AsEnumerable(), cancellationToken);

        return _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);
    }
}