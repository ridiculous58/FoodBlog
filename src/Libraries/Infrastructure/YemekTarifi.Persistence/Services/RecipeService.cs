using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipeAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Recipe> InsertAsync(Recipe recipe)
        {
            var addedRecipe = await _repository.InsertAsync(recipe);
            await _repository.UnitOfWork.SaveChangesAsync();
            return addedRecipe;
        }

        public async Task InsertManyAsync(IEnumerable<Recipe> recipes)
        {
            await _repository.InsertManyAsync(recipes);
            await _repository.UnitOfWork.SaveChangesAsync();
        }
    }
}