using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Admin.Controllers;
[Authorize(Roles = "3")]
[Area("Admin")]
[Route("Admin/dashboard")]
public class DashboardAdminController : Controller
{
	private AccountService accountService;
	private EmployeeService employeeService;
	public DashboardAdminController(AccountService _accountService, EmployeeService _employeeService)
	{
		accountService = _accountService;
		employeeService = _employeeService;
	}
	[Route("")]
    [Route("index")]
    public IActionResult Index()
    {
		ViewBag.employees = employeeService.findAll();
		NhanVien nv = accountService.FindByUsername(User.FindFirst(ClaimTypes.Name).Value);
		return View("Index", nv);
    }
}
