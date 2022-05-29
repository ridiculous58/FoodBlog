using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using YemekTarifi.Application.Features.Queries.ViewModels;

namespace YemekTarifi.Application.Features.Queries.GetRecipeById
{
    public class GetRecipeByIdQuery : IRequest<RecipeViewModel>
    {
        public string Id { get; set; }

        public GetRecipeByIdQuery(string id)
        {
            Id = id;
        }
    }
}
