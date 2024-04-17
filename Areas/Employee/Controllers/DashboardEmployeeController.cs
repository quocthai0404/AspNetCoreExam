using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspdotNetCoreMVCExam.Areas.Employee.Controllers;
[Authorize(Roles = "1")]
[Area("Employee")]
[Route("Employee/dashboard")]
public class DashboardEmployeeController : Controller
{
    private AccountService accountService;
    public DashboardEmployeeController(AccountService _accountService) {
        accountService=_accountService;
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
