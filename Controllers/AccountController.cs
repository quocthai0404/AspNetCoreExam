using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Controllers;
[Route("account")]
public class AccountController : Controller
{
	private AccountService accountService;
	public AccountController(AccountService _accountService)
	{
		this.accountService = _accountService;
	}

	[Route("changeInfo")]
	public IActionResult changeInfo(NhanVien nv, string newpassword, string repassword)
	{
		var username = User.FindFirst(ClaimTypes.Name).Value;
		NhanVien currentAccount = accountService.FindByUsername(username);
		if (string.IsNullOrEmpty(nv.Hoten))
		{
			TempData["Msg"] = "Invalid input data";
			return currentAccount.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		if (nv.Ngaysinh == DateTime.MinValue)
		{
			TempData["Msg"] = "Invalid date";
			return currentAccount.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}



		if (!string.IsNullOrEmpty(newpassword) && newpassword == repassword)
		{
			currentAccount.Password = BCrypt.Net.BCrypt.HashPassword(newpassword);
			
		}
		else if (!string.IsNullOrEmpty(newpassword))
		{
			TempData["Msg"] = "Passwords do not match";
			return currentAccount.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		currentAccount.Hoten = nv.Hoten;
		currentAccount.Ngaysinh = nv.Ngaysinh;

		if (accountService.Update(currentAccount))
		{
			
			TempData["Msg"] = "Update info success";
			return currentAccount.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });

		}
		else
		{
			TempData["Msg"] = "Update info failed";
			return currentAccount.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
	}
}
