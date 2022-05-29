using MediatR;
using YemekTarifi.Application.Interfaces;

namespace YemekTarifi.Application.Features.Commands.DeleteRecipeById;

public class DeleteRecipeByIdCommandHandler : IRequestHandler<DeleteRecipeByIdCommand,bool>
{
    private readonly IRecipeService _recipeService;
    public DeleteRecipeByIdCommandHandler(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    public async Task<bool> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        return await _recipeService.DeleteById(request.Id);
    }
}