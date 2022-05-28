using MediatR;
using YemekTarifi.Application.Features.Queries.ViewModels;

namespace YemekTarifi.Application.Features.Queries.GetRecipeAll;

public class GetRecipeAllQuery : IRequest<IEnumerable<RecipeViewModel>>
{
    
}