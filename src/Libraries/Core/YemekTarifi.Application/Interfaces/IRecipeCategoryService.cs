using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Interfaces;

public interface IRecipeCategoryService
{
    Task<RecipeCategory> GetRecipeCategoryByIdAsync(Guid id);
    Task<IEnumerable<RecipeCategory>> GetRecipeCategoryAllAsync();
    Task<RecipeCategory> InsertAsync(RecipeCategory recipe);
    Task InsertManyAsync(IEnumerable<RecipeCategory> recipes);
}