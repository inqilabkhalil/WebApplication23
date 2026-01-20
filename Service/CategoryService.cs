using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication23.Data;
using WebApplication23.Models;
using WebApplication23.Service.Interface;
using WebApplication23.ViewModels.Category;

namespace WebApplication23.Service;

public class CategoryService:ICategoryService
{
    private readonly AppDbContext _context;
    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    
    public async  Task<IEnumerable<CategoryVM>> GetAllAdminAsync()
    {
        var categories = await _context.Categories.Select(p => new CategoryVM()
        {
            Id = p.Id,
            Work = p.Work


            
        }).ToListAsync();
        return categories;


    }

    public async Task CreateAsync(CategoryCreateVM model)
    {
        var data = new Category
        {
            Work = model.Work
        };
        await _context.Categories.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _context.Categories.FindAsync(id);
        _context.Categories.Remove(data);
        await _context.SaveChangesAsync();

    }

    public async Task<CategoryDetailVM> GetByIdAsync(int id)
    {
        var data = await _context.Categories.FindAsync(id);
        return new CategoryDetailVM
        {
            Id = data.Id,
            Work = data.Work,
            CreatedDate = data.CreatedAt,
        };
    }

    public async Task UpdateAsync(int id, CategoryUpdateVM model)
    {
        var data = await _context.Categories.FindAsync(id);
        data.Work = model.Work;
        await _context.SaveChangesAsync();

    }

    public async Task<SelectList> GetAllCategories()
    {
        var data =  await _context.Categories.ToListAsync();
        return new SelectList(data, "Id","Work");
    }
}