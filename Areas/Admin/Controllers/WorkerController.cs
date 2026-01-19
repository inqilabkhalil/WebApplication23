using Microsoft.AspNetCore.Mvc;

namespace WebApplication23.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}