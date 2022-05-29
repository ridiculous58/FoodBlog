using MediatR;

namespace YemekTarifi.Application.Features.Commands.DeleteRecipeById;

public class DeleteRecipeByIdCommand : IRequest<bool>
{
    public string Id { get; set; }

    public DeleteRecipeByIdCommand(string id)
    {
        Id = id;
    }
}