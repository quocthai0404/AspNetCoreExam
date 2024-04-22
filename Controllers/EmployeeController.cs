using Microsoft.AspNetCore.Mvc;

namespace AspdotNetCoreMVCExam.Controllers;
public class EmployeeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
