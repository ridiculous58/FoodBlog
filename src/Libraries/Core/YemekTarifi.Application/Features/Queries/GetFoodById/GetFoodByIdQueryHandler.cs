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

namespace YemekTarifi.Application.Features.Queries.GetFoodById
{
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodCategoryViewModel>
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;
        public GetFoodByIdQueryHandler(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        public async Task<FoodCategoryViewModel> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            var food = await _foodService.GetFoodByIdAsync(request.Id);
            return _mapper.Map<FoodCategoryViewModel>(food);
        }
    }
}
