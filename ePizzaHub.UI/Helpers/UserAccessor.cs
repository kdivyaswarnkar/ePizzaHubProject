using ePizzaHub.Models;
using System.Security.Claims;
using System.Text.Json;

namespace ePizzaHub.UI.Helpers
{
    public class UserAccessor :IUserAccessor
    {
        IHttpContextAccessor _HttpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public UserModel GetUser()
        {
            if (_HttpContextAccessor.HttpContext.User != null &&
                 _HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string userData = _HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                UserModel user = JsonSerializer.Deserialize<UserModel>(userData);
                return user;
            }
            return null;
        }
    }
}
