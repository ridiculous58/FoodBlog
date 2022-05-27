using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Mapping.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodCategoryViewModel>()
                .ReverseMap();
        }
    }
}
