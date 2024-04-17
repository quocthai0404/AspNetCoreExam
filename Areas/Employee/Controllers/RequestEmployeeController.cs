using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Employee.Controllers;
[Area("Employee")]
[Route("Employee/Request")]
public class RequestEmployeeController : Controller
{
    private AccountService accountService;
    public RequestEmployeeController(AccountService _accountService)
    {
        accountService = _accountService;
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
        
        return View("ViewRequest", findEmpByCookie());
    }
}
