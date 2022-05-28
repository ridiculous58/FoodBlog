using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Services;

public class RecipeCategoryService : IRecipeCategoryService
{
    private readonly IRepository<RecipeCategory> _repository;


    public RecipeCategoryService(IRepository<RecipeCategory> repository)
    {
        _repository = repository;
    }

    public Task<RecipeCategory> GetRecipeCategoryByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<IEnumerable<RecipeCategory>> GetRecipeCategoryAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task<RecipeCategory> InsertAsync(RecipeCategory recipe)
    {
        var recipeCategory =  await _repository.InsertAsync(recipe);
        await _repository.UnitOfWork.SaveChangesAsync();
        return recipeCategory;
    }

    public Task InsertManyAsync(IEnumerable<RecipeCategory> recipes)
    {
        _repository.InsertManyAsync(recipes);
        return _repository.UnitOfWork.SaveChangesAsync();
    }
}