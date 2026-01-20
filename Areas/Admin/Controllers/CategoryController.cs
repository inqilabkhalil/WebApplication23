using Microsoft.AspNetCore.Mvc;
using WebApplication23.Service.Interface;
using WebApplication23.ViewModels.Category;

namespace WebApplication23.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) 
    {
        _categoryService = categoryService;
    }


    // GET
    public async Task<IActionResult> Index()
    {
        var data = await _categoryService.GetAllAdminAsync();
        return View(data);

    }

    public IActionResult Create()
    {
        return View();


    }

    [HttpPost]

    public async Task<IActionResult> Create(CategoryCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _categoryService.CreateAsync(model);
        return RedirectToAction("Index");
        
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _categoryService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }
        await _categoryService.DeleteAsync(data.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]

    public async Task<IActionResult> Detail(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _categoryService.GetByIdAsync(id.Value);
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

        var data = await _categoryService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }

        var vm = new CategoryUpdateVM()
        {
            Id = data.Id,
            Work = data.Work,
        };
        return View(vm);
    }

    [HttpPost]

    public async Task<IActionResult> Update(int? id, CategoryUpdateVM model)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var data = await _categoryService.GetByIdAsync(id.Value);
        if (data == null)
        {
            return NotFound();
        }

        
        await  _categoryService.UpdateAsync(data.Id, model);
        return RedirectToAction("Index");

    }
    
    
    






















}