using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace saas_performance_blazor.Areas.Admin.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public async Task<IActionResult> Login([FromForm] string Email, string Password, string CallBackRoute = "/")
        {
            if(Email == "a@a.com" && Password == "0000")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(claimsPrincipal);
            }
            return Redirect(CallBackRoute);
        }
    }
}
