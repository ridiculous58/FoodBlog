using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Queries.GetRecipeById
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeViewModel>
    {
        private readonly IRecipeService _RecipeService;
        private readonly IMapper _mapper;
        public GetRecipeByIdQueryHandler(IRecipeService RecipeService, IMapper mapper)
        {
            _RecipeService = RecipeService;
            _mapper = mapper;
        }

        public async Task<RecipeViewModel> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var id))
                return null;
            
            var recipe = await _RecipeService.GetRecipeByIdAsync(id);
            return _mapper.Map<RecipeViewModel>(recipe);
        }
    }
}
