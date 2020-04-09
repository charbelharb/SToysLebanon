using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Core
{
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
        private string GetCurrentUser()
        {
            string result = "";
            ClaimsPrincipal _curUser = HttpContext.User;
            if (_curUser != null)
            {
                Claim _curUserId = _curUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (_curUserId != null && !string.IsNullOrEmpty(_curUserId.Value))
                {
                    result = _curUserId.Value;
                }
            }
            return result;
        }

        protected string CurrentUser => GetCurrentUser();
    }
}
