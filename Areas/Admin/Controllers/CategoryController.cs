using Microsoft.AspNetCore.Mvc;

namespace WebApplication23.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}