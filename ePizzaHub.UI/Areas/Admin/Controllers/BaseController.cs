using ePizzaHub.UI.Helpers;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize(Roles = "Admin")]
    public class BaseController : Controller
    {
     
    }
}
