using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Interfaces
{
    public interface IFoodService
    {
        Task<Food> GetFoodByIdAsync(Guid id);
        Task<bool> InsertAsync(Food food);
    }
}
