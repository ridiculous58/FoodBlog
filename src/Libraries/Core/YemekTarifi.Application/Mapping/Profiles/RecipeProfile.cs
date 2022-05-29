using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Dtos;
using YemekTarifi.Application.Features.Queries.ViewModels;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Application.Mapping.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeViewModel>()
                .ReverseMap(); 
            CreateMap<RecipeCategory,RecipeCategoryViewModel>()
                .ReverseMap(); 
            CreateMap<Recipe,RecipeDto>()
                .ReverseMap();
        }
    }
}
