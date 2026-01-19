using WebApplication23.ViewModels.Category;
using WebApplication23.ViewModels.Worker;

namespace WebApplication23.Service.Interface;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryVM>> GetAllAdminAsync();
    Task CreateAsync(CategoryCreateVM model);
    Task DeleteAsync(int id);
    Task<CategoryDetailVM> GetByIdAsync(int id);
    Task UpdateAsync(int Id,CategoryUpdateVM model);


}