using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class AuthController : Controller
{
        [HttpPost("login")]
        public IActionResult Login([FromBody] string userName, [FromBody] string password)
        {
            if (password != "p@ssw0rd")
            {
                return NotFound();
            }
            var identity = new ClaimsIdentity("password");
            identity.AddClaim(new Claim(ClaimTypes.Name, "DefaultUser"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            if(userName == "admin"){
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }
            HttpContext.Authentication.SignInAsync("CustomAuth", new ClaimsPrincipal(identity)).Wait();
            return new ObjectResult("success");
        }

}