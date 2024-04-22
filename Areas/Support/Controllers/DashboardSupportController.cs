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
	private RequestService requestService;
	public DashboardSupportController(AccountService _accountService, RequestService _requestService)
	{
		accountService = _accountService;
		requestService = _requestService;
	}
	[Route("")]
    [Route("index")]
    public IActionResult Index()
    {
		var username = User.FindFirst(ClaimTypes.Name).Value;
		NhanVien nv = accountService.FindByUsername(username);
		ViewBag.requests = requestService.findAllBySupport(username);
		return View("Index", nv);
	}


}
