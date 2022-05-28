using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<IEnumerable<Recipe>> GetRecipeAllAsync();
        Task<Recipe> InsertAsync(Recipe recipe);
        Task InsertManyAsync(IEnumerable<Recipe> recipes);
    }
}
