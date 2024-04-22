using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using AspdotNetCoreMVCExam.Models;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Controllers;
[Route("request")]
public class RequestController : Controller
{
	private RequestService requestService;
	public RequestController(RequestService _requestService)
	{
		requestService = _requestService;
	}
	[HttpPost]
	[Route("addRequest")]
	public IActionResult addRequest(string title, string content, int priority)
	{
		TempData["Msg"] = "Send Request Failed";
		if (requestService.add(new YeuCau
		{
			Tieude = title,
			Noidung = content,
			Ngaygui = DateTime.Today,
			Madouutien = priority,
			ManvGui = User.FindFirst(ClaimTypes.Name)?.Value,
			ManvXuly = null
		}))
		{
			TempData["Msg"] = "Send Request Success";
		}
		return RedirectToAction("index", "dashboard", new { Area = "Employee" });
	}
}
