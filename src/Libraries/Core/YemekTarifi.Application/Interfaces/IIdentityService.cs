using Microsoft.AspNetCore.Identity;
using YemekTarifi.Application.Dtos;

namespace YemekTarifi.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityUser> Login(LoginDto loginDto);
        Task<IdentityUser> Register(RegisterDto registerDto, IEnumerable<string> roles);
        Task Logout();
    }
}
