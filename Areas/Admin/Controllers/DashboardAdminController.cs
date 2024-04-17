using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspdotNetCoreMVCExam.Areas.Admin.Controllers;
[Authorize(Roles = "3")]
[Area("Admin")]
[Route("Admin/dashboard")]
public class DashboardAdminController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
