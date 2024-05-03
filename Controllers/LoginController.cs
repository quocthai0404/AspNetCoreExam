using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Controllers;
[Route("Login")]
public class LoginController : Controller
{
    private AccountService accountService;
    public LoginController(AccountService _accountService)
    {
        accountService = _accountService;
    }

    [Route("~/")]
    [Route("Index")]
    [Route("")]
    public IActionResult Index()
    {
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
		if (username != null)
		{
			NhanVien nv = accountService.FindByUsername(username);
			return nv.Quyen == 1
				? RedirectToAction("index", "dashboard", new { Area = "Employee" })
				: RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		return View("Login");

	}
    [Route("Employee")]
	public IActionResult Employee()
	{
		return View("Index");
	}
    [Route("Support")]
    public IActionResult Support() {
		return View("NhanVienSupport");
	}
	[HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(string username, string password) {
        if (accountService.Login(username, password))
        {
            NhanVien nv = accountService.FindByUsername(username);
            var claimns = new List<Claim>();
            claimns.Add(new Claim(ClaimTypes.Name, username));
            claimns.Add(new Claim(ClaimTypes.Role, nv.Quyen.ToString()));
            /*luu secutity vao cookie*/
            var claimIdendity = new ClaimsIdentity(claimns, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincial = new ClaimsPrincipal(claimIdendity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincial);
            
            switch (nv.Quyen)
            {
                case 1:
                    TempData["Msg"] = $"Welcome {nv.Hoten}";
					return RedirectToAction("index", "dashboard", new { Area = "Employee" });
				case 2:
                    TempData["Msg"] = $"Welcome {nv.Hoten}";
                    return RedirectToAction("index", "dashboard", new { Area = "Support" });
                default:
                    TempData["Msg"] = "Login failed!";
                    return RedirectToAction("Index");
            }
        }
        else {
            TempData["Msg"] = "Login failed!";
            return RedirectToAction("Index");
        }
    }

    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        TempData["Msg"] = "Log out success";
        return RedirectToAction("Index");
    }
}
