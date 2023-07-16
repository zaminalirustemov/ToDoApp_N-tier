using Microsoft.AspNetCore.Mvc;
using ToDoApp_N_tier.Business.Interfaces;
using ToDoApp_N_tier.Dtos.WorkDtos;
using ToDoApp_N_tier.UI.Extensions;

namespace ToDoApp_N_tier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAllAsync();
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            var response= await _workService.CreateAsync(workCreateDto);
            return this.ResponseRedirectToAction(response, nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response= await _workService.GetByIdAsync<WorkUpdateDto>(id);
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            var response= await _workService.UpdateAsync(workUpdateDto);
            return this.ResponseRedirectToAction(response,nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var respone= await _workService.RemoveAsync(id);
            return this.ResponseRedirectToAction(respone, nameof(Index));
        }
    }
}