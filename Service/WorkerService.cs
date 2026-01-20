using Microsoft.EntityFrameworkCore;
using WebApplication23.Data;
using WebApplication23.Models;
using WebApplication23.Service.Interface;
using WebApplication23.ViewModels;
using WebApplication23.ViewModels.Category;
using WebApplication23.ViewModels.Worker;

namespace WebApplication23.Service
{
    public class WorkerService : IWorkerService
    {

        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public WorkerService(AppDbContext context, IFileService fileService)
        {
            _fileService = fileService;


            _context = context;
        }

        public async Task<IEnumerable<WorkerUIVM>> GetAllAsync()
        {
            var workers = await _context.Worker.Select(item => new WorkerUIVM
            {
                Image = item.Image,
                Description = item.Description,
                CategoryName = item.Category.Work,
                FullName = item.FullName
            }).ToListAsync();
            return workers;

        }

        public async Task<IEnumerable<WorkerVM>> GetAllAdminAsync()
        {
            var workers = await _context.Worker.Select(item => new WorkerVM
            {
                Id = item.Id,
                Image = item.Image,
                Description = item.Description,
                CategoryName = item.Category.Work,
                FullName = item.FullName
            }).ToListAsync();
            return workers;
        }

        public async Task CreateAsync(WorkerCreateVM model)
        {
            var fileName = _fileService.GenerateUniqueFileName(model.Image.FileName);
            var path = _fileService.GeneratePath("images", fileName);
            await _fileService.UploadAsync(model.Image, path);
            var data = new Worker
            {
                Image = fileName,
                Description = model.Description,
                FullName = model.FullName,
                CategoryId = model.CategoryId,
            };
            await _context.Worker.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, WorkerUpdateVM model)
        {

            var data = await _context.Worker.FindAsync(id);
            var oldPath = _fileService.GeneratePath("images", data.Image);
            _fileService.Delete(oldPath);
            var fileName = _fileService.GenerateUniqueFileName(model.Image.FileName);
            var path = _fileService.GeneratePath("images", fileName);
           await  _fileService.UploadAsync(model.Image, path);
            data.Image = fileName;
            data.Description = model.Description;
            data.CategoryId = model.CategoryId;
            data.FullName = model.FullName;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Worker.FindAsync(id);
            if (data == null)
            {
                return;
            }
            var oldPath = _fileService.GeneratePath("images", data.Image);
            
            _fileService.Delete(oldPath);
            _context.Worker.Remove(data);
            await _context.SaveChangesAsync();

        }

        public async Task<WorkerDetailVM> GetByIdAsync(int id)
        {
            var data = await _context.Worker.Include(p=>p.Category).FirstOrDefaultAsync(c=>id==c.Id);
            return new WorkerDetailVM()
            {
                Image = data.Image,
                Description = data.Description,
                CategoryName = data.Category.Work,
                FullName = data.FullName,

            };
        }
    }
}
