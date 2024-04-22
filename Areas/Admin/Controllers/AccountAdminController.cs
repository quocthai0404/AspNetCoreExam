using AspdotNetCoreMVCExam.Helper;
using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/account")]
public class AccountAdminController : Controller

{
	private AccountService accountService;
	private IWebHostEnvironment webHostEnvironment;
	public AccountAdminController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
	{
		this.accountService = _accountService;
		this.webHostEnvironment = _webHostEnvironment;
	}

	[Route("changeInfoAdmin")]
	public IActionResult changeInfoAdmin(NhanVien nv, string newpassword, string repassword)
	{
		var username = User.FindFirst(ClaimTypes.Name).Value;
		NhanVien currentAccount = accountService.FindByUsername(username);
		if (string.IsNullOrEmpty(nv.Hoten))
		{
			TempData["Msg"] = "Invalid input data";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}
		if (nv.Ngaysinh == DateTime.MinValue)
		{
			TempData["Msg"] = "Invalid date";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}



		if (!string.IsNullOrEmpty(newpassword) && newpassword == repassword)
		{
			currentAccount.Password = BCrypt.Net.BCrypt.HashPassword(newpassword);

		}
		else if (!string.IsNullOrEmpty(newpassword))
		{
			TempData["Msg"] = "Passwords do not match";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}
		currentAccount.Hoten = nv.Hoten;
		currentAccount.Ngaysinh = nv.Ngaysinh;

		if (accountService.Update(currentAccount))
		{

			TempData["Msg"] = "Update info success";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });

		}
		else
		{
			TempData["Msg"] = "Update info failed";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}
	}
	

	[HttpPost]
	[Route("changePhotoAdmin")]
	public IActionResult changePhotoAdmin(IFormFile file)
	{
		var nv = accountService.FindByUsername(User.FindFirst(ClaimTypes.Name).Value);
		if (file == null)
		{
			TempData["Msg"] = "Please upload your photo";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
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
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}
		else
		{
			TempData["Msg"] = "Upload your photo failed";
			return RedirectToAction("Index", "dashboard", new { Area = "Admin" });
		}


	}
}
