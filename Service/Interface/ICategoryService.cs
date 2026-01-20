using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication23.ViewModels.Category;
using WebApplication23.ViewModels.Worker;

namespace WebApplication23.Service.Interface;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryVM>> GetAllAdminAsync();
    public Task CreateAsync(CategoryCreateVM model);
    public Task DeleteAsync(int id);
    public Task<CategoryDetailVM> GetByIdAsync(int id);
    public Task UpdateAsync(int id , CategoryUpdateVM model);
    public Task <SelectList> GetAllCategories();
    

    


}