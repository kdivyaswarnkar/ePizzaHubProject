using ePizzaHub.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Areas.User.Controllers
{
    [Area("User")]
    [CustomAuthorize(Roles = "User")]
    public class BaseController : Controller
    {
    
    }
}
