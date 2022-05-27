using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Dtos;

namespace YemekTarifi.Application.Mapping.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<IdentityUser, RegisterDto>()
                .ReverseMap();
        }
    }
}
