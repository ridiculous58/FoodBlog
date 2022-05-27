using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain;

namespace YemekTarifi.Application.Dtos
{
    public class LoginDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
