using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/login")]
public class LoginAdminController : Controller
{
	private AccountService accountService;
	public LoginAdminController(AccountService _accountService)
	{
		accountService = _accountService;
	}
	//[Route("~/")]
	[Route("")]
	[Route("Index")]
	public IActionResult Index()
	{
		var username = User.FindFirst(ClaimTypes.Name)?.Value;
		if (username != null)
		{
			NhanVien nv = accountService.FindByUsername(username);
			return nv.Quyen == 3 ? RedirectToAction("index", "dashboard", new { Area = "Admin" }) : View("Index"); 
		}
		return View("Index");
	}
	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login(string username, string password)
	{
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
			TempData["Msg"] = $"Welcome {nv.Hoten}";
			return RedirectToAction("Index", "Dashboard", new { Area = "Admin"});
			
		}
		else
		{
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
