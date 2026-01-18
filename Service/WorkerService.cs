using Microsoft.EntityFrameworkCore;
using WebApplication23.Data;
using WebApplication23.Service.Interface;
using WebApplication23.ViewModels;

namespace WebApplication23.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;
        public WorkerService(AppDbContext context)
        {
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
    }
}
