using MediatR;
using System.Linq.Expressions;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Queries.GetRecipeAll;

public class GetRecipeAllQuery : IRequest<IEnumerable<RecipeViewModel>>
{
    public bool IsOrderByDescendingForCreatedDate { get; set; }

    public GetRecipeAllQuery(bool isOrderByDescendingForCreatedDate = false)
    {
        IsOrderByDescendingForCreatedDate = isOrderByDescendingForCreatedDate;
    }
}