using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Employee.Controllers;
[Area("Employee")]
[Route("Employee/Request")]
public class RequestEmployeeController : Controller
{
    private AccountService accountService;
    private RequestService requestService;
    private PriorityService priorityService;
    public RequestEmployeeController(AccountService _accountService, RequestService _requestService, PriorityService _priorityService)
    {
        accountService = _accountService;
        requestService = _requestService;
        priorityService = _priorityService;
    }
    public NhanVien findEmpByCookie() {
        return accountService.FindByUsername(User.FindFirst(ClaimTypes.Name).Value);
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Dashboard");
    }
	[Route("Create")]
	public IActionResult Create()
	{
		return RedirectToAction("Index", "Dashboard");
	}
    [Route("ViewRequest")]
    public IActionResult ViewRequest() {
        ViewBag.requests = requestService.findAllBySender(User.FindFirst(ClaimTypes.Name).Value);
        
        return View("ViewRequest", findEmpByCookie());
    }
}
