using Microsoft.AspNetCore.Mvc;
using WebApplication23.Service.Interface;

namespace WebApplication23.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkerController : Controller
{
    private readonly IWorkerService _workerService;
public WorkerController(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    public async  Task<IActionResult> Index()
    {
        var data = await _workerService.GetAllAdminAsync();
        return View(data);
    }

}