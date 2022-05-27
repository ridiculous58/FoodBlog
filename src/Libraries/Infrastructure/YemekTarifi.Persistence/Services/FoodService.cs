using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Services
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _repository;

        public FoodService(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<Food> GetFoodByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(Food food)
        {
            await _repository.InsertAsync(food);
            return true;
        }
    }
}
