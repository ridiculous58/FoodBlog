using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Dtos;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Features.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<bool>
    {
        public RecipeDto RecipeDto { get; set; }

        public CreateRecipeCommand(RecipeDto RecipeDto)
        {
            RecipeDto = RecipeDto;
        }
    }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, bool>
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public CreateRecipeCommandHandler(IRecipeService RecipeService, IMapper mapper)
        {
            _recipeService = RecipeService;
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
