using AspdotNetCoreMVCExam.Helper;
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
	private IWebHostEnvironment webHostEnvironment;
	public AccountController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
	{
		this.accountService = _accountService;
		this.webHostEnvironment = _webHostEnvironment;
	}
	
	[HttpPost]
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
	[HttpPost]
	[Route("changePhoto")]
	public IActionResult changePhoto(IFormFile file) {
		var nv = accountService.FindByUsername(User.FindFirst(ClaimTypes.Name).Value);
		if (file == null) {
			TempData["Msg"] = "Please upload your photo";
			return nv.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		var fileName = FileNameHelper.generateFileName(file.FileName);
		var path = Path.Combine(webHostEnvironment.WebRootPath, "dist/img", fileName);
		using (var fileStream = new FileStream(path, FileMode.Create))
		{
			file.CopyTo(fileStream);
		}
		nv.Hinhanh = fileName;
		if (accountService.Update(nv))
		{
			TempData["Msg"] = "Upload your photo success";
			return nv.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		else
		{
			TempData["Msg"] = "Upload your photo failed";
			return nv.Quyen == 1
			  ? RedirectToAction("index", "dashboard", new { Area = "Employee" })
			  : RedirectToAction("index", "dashboard", new { Area = "Support" });
		}
		
		
	}

}
