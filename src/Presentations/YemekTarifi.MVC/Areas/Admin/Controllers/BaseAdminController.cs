using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekTarifi.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public abstract class BaseAdminController : Controller
    {
    }
}
