using Microsoft.AspNetCore.Mvc;

namespace AspdotNetCoreMVCExam.Controllers;
[Route("Denied")]
public class DeniedController : Controller
{
	[Route("index")]
	public IActionResult Index()
	{
		return View();
	}
}
