using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/request")]
public class RequestAdminController : Controller
{
	private AccountService accountService;
	private RequestService requestService;
	public RequestAdminController(AccountService _accountService, RequestService _requestService)
	{
		accountService = _accountService;
		requestService = _requestService;
	}

	[Route("")]
	[Route("Index")]
	public IActionResult Index()
	{
		ViewBag.requests = requestService.findAllByAdmin();
		NhanVien nv = accountService.FindByUsername(User.FindFirst(ClaimTypes.Name).Value);
		return View("Index", nv);
	}

	[Route("AddSupportToRequest")]
	public IActionResult AddSupportToRequest(int requestId, string username) {
		YeuCau yc = requestService.findById(requestId);
		yc.ManvXuly = username;
		if (requestService.update(yc)) {
			return Json(new { success = true, redirectTo = Url.Action("Index") });
		}
		return Json(new { success = false, redirectTo = Url.Action("Index") });
	}
}
