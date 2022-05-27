using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using YemekTarifi.Application.Features.Queries.ViewModels;

namespace YemekTarifi.Application.Features.Queries.GetFoodById
{
    public class GetFoodByIdQuery : IRequest<FoodCategoryViewModel>
    {
        public Guid Id { get; set; }
    }
}
