using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthenticationController : Controller
{
    public async Task<IActionResult> LogIn(string username, string password)
    {
        return BadRequest();
    }
}
