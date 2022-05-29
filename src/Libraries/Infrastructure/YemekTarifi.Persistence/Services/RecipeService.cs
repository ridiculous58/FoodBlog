using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public IQueryable<Recipe> Table => _repository.Table;

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

        public async Task<bool> DeleteById(string id)
        {
            if (!Guid.TryParse(id, out var idGuid))
                return false;
            
            var recipe = await _repository.GetByIdAsync(idGuid);
           
            if (recipe == null)
                return false;
            
            await _repository.DeleteAsync(recipe);
            await _repository.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Recipe> UpdateAsync(Recipe recipe)
        {
            var updatedRecipe = await _repository.UpdateAsync(recipe); 
            await _repository.UnitOfWork.SaveChangesAsync();
            return updatedRecipe;
        }
    }
}