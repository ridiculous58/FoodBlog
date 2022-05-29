using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Dtos;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeByIdAsync(Guid id);
        public IQueryable<Recipe> Table { get; }
        Task<IEnumerable<Recipe>> GetRecipeAllAsync();
        Task<Recipe> InsertAsync(Recipe recipe);
        Task InsertManyAsync(IEnumerable<Recipe> recipes);
        Task<bool> DeleteById(string id);
        Task<Recipe> UpdateAsync(Recipe recipe);
        
    }
}
