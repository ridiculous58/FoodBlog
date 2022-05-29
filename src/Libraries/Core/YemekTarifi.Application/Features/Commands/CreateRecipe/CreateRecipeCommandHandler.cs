using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, bool>
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public CreateRecipeCommandHandler(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _mapper.Map<Recipe>(request.RecipeDto);
            await _recipeService.InsertAsync(recipe);
            return true;
        }
    }

}
