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

		if ((string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to) && priority == -1))
		{
			//tim all
			return new JsonResult(requestService.findAllBySenderDynamic(username));
		}
		else if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
		{
			if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to)) {
				if (priority != -1)
				{
					return new JsonResult(requestService.findByPriorityDynamic(priority, username));
					
				}
				
			}
			//loi
			return new JsonResult("400");

		}
		else
		{
			//neu co ca 2
			DateTime From = DateTime.ParseExact(from, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			DateTime To = DateTime.ParseExact(to, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			if (!(string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to)))
			{
				if (priority == -1)
				{
					//tim theo from to, ko tim theo pri |(all)
					return new JsonResult(requestService.findByDateDynamic(From, To, username));
				}
				else
				{
					//tim theo ca 3
					return new JsonResult(requestService.findByDateAndPriorityDynamic(From, To, priority, username));
				}
			}
			else
			{
				if (priority == -1)
				{
					// tim theo pri = -1
					return new JsonResult(requestService.findAllBySenderDynamic(username));
				}
				else
				{
					//tim theo pri 
					return new JsonResult(requestService.findByPriorityDynamic(priority, username));
				}
			}

		}


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
		if ((string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to) && priority == -1))
		{
			//tim all
			return new JsonResult(requestService.findAllDynamicByAdmin());
		}
		else if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
		{
			if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
			{
				if (priority != -1)
				{
					return new JsonResult(requestService.findByPriorityDynamicByAdmin(priority));

				}

			}
			//loi
			return new JsonResult("400");

		}
		else
		{
			//neu co ca 2
			DateTime From = DateTime.ParseExact(from, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			DateTime To = DateTime.ParseExact(to, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			if (!(string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to)))
			{
				if (priority == -1)
				{
					//tim theo from to, ko tim theo pri |(all)
					return new JsonResult(requestService.findByDateDynamicByAdmin(From, To));
				}
				else
				{
					//tim theo ca 3
					return new JsonResult(requestService.findByDateAndPriorityDynamicByAdmin(From, To, priority));
				}
			}
			else
			{
				if (priority == -1)
				{
					// tim theo pri = -1
					return new JsonResult(requestService.findAllDynamicByAdmin());
				}
				else
				{
					//tim theo pri 
					return new JsonResult(requestService.findByPriorityDynamicByAdmin(priority));
				}
			}

		}


	}

	[Route("ajax5")]
	public IActionResult ajax5(string from, string to, int priority)
	{
		var username = User.FindFirst(ClaimTypes.Name)?.Value;
		if ((string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to) && priority == -1))
		{
			//tim all
			return new JsonResult(requestService.findAllDynamicBySupport(username));
		}
		else if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
		{
			if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
			{
				if (priority != -1)
				{
					return new JsonResult(requestService.findByPriorityDynamicBySupport(priority, username));

				}

			}
			//loi
			return new JsonResult("400");

		}
		else
		{
			//neu co ca 2
			DateTime From = DateTime.ParseExact(from, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			DateTime To = DateTime.ParseExact(to, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			if (!(string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to)))
			{
				if (priority == -1)
				{
					//tim theo from to, ko tim theo pri |(all)
					return new JsonResult(requestService.findByDateDynamicBySupport(From, To, username));
				}
				else
				{
					//tim theo ca 3
					return new JsonResult(requestService.findByDateAndPriorityDynamicBySupport(From, To, priority, username));
				}
			}
			else
			{
				if (priority == -1)
				{
					// tim theo pri = -1
					return new JsonResult(requestService.findAllDynamicBySupport(username));
				}
				else
				{
					//tim theo pri 
					return new JsonResult(requestService.findByPriorityDynamicBySupport(priority, username));
				}
			}

		}


	}
}
