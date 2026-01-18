using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication23.Service.Interface;


namespace WebApplication23.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWorkerService _service;

        public HomeController(IWorkerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var workers = await _service.GetAllAsync();

            return View(workers);
        }

       
        
       
    }
}
