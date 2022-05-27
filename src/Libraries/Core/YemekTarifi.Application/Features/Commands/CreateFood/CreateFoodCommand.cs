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

namespace YemekTarifi.Application.Features.Commands.CreateFood
{
    public class CreateFoodCommand : IRequest<bool>
    {
        public FoodDto FoodDto { get; set; }
    }

    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, bool>
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;

        public CreateFoodCommandHandler(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = _mapper.Map<Food>(request.FoodDto);
            return await _foodService.InsertAsync(food);
        }
    }

}
