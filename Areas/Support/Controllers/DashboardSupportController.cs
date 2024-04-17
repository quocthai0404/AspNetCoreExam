using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Support.Controllers;
[Authorize(Roles = "2")]
[Area("Support")]
[Route("Support/dashboard")]
public class DashboardSupportController : Controller
{
	private AccountService accountService;
	public DashboardSupportController(AccountService _accountService)
	{
		accountService = _accountService;
	}
	[Route("")]
    [Route("index")]
    public IActionResult Index()
    {
		var username = User.FindFirst(ClaimTypes.Name).Value;
		NhanVien nv = accountService.FindByUsername(username);
		return View("Index", nv);
	}


}
