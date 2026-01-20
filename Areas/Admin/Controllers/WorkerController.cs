using Microsoft.AspNetCore.Mvc;
using WebApplication23.Service.Interface;
using WebApplication23.ViewModels.Category;
using WebApplication23.ViewModels.Worker;

namespace WebApplication23.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkerController : Controller
{
    private readonly IWorkerService _workerService;
    private readonly ICategoryService _categoryService;
public WorkerController(IWorkerService workerService, ICategoryService categoryService)
    {
        _workerService = workerService;
        _categoryService = categoryService;
    }

    public async  Task<IActionResult> Index()
    {
        var data = await _workerService.GetAllAdminAsync();
        return View(data);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Category = await _categoryService.GetAllCategories();
        return View();


    }

    [HttpPost]

    public async Task<IActionResult> Create(WorkerCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Category = await _categoryService.GetAllCategories();
            return View(model);
        }
        await _workerService.CreateAsync(model);
        return RedirectToAction("Index");
        
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        //debug at burra
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _workerService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }
        await _workerService.DeleteAsync(data.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]

    public async Task<IActionResult> Detail(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _workerService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }
        
        return View(data);
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _workerService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }

        var vm = new WorkerUpdateVM()
        {
            Id = data.Id,
            
        };
        return View(vm);
    }

    [HttpPost]

    public async Task<IActionResult> Update(int? id, WorkerUpdateVM model)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _workerService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }

        
        await  _workerService.UpdateAsync(data.Id, model);
        return RedirectToAction("Index");

    }


}