using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Controllers;
[Route("ajax")]
public class AjaxController : Controller
{
	private EmployeeService employeeService;
	private PriorityService priorityService;
	private RequestService requestService;
	public AjaxController(EmployeeService _employeeService, PriorityService _priorityService, RequestService _requestService)
	{
		employeeService = _employeeService;
		priorityService = _priorityService;
		requestService = _requestService;
	}
	[Route("Home")]
	public IActionResult Home() { 
		return RedirectToAction("Index", "Login");
	}
	[Route("findSupport")]
	public IActionResult Index()
	{
		return new JsonResult(employeeService.findSupportEmps());
	}
	[Route("findPriority")]
	public IActionResult index2()
	{
		return new JsonResult(priorityService.findAll());
	}
	[Route("ajax1")]
	public IActionResult ajax1(string from, string to, int priority)
	{
		var username = User.FindFirst(ClaimTypes.Name)?.Value;
		return new JsonResult(requestService.find(from, to, priority, username));
	}

	

	[Route("ajax2")]
	public IActionResult ajax2(string username) {
		return new JsonResult(requestService.findAllBySenderDynamic(username));
	}

	[Route("ajax3")]
	public IActionResult ajax3(int requestID)
	{

		return new JsonResult(new {listsupport = employeeService.findSupportEmpDynamic(), requestID= requestID } );
	}

	[Route("ajax4")]
	public IActionResult ajax4(string from, string to, int priority)
	{
		return new JsonResult(requestService.findByAdmin(from, to, priority));

	}

	[Route("ajax5")]
	public IActionResult ajax5(string from, string to, int priority)
	{
		var username = User.FindFirst(ClaimTypes.Name)?.Value;
		return new JsonResult(requestService.findBySupport(from, to, priority, username));
	}

	

	
}
