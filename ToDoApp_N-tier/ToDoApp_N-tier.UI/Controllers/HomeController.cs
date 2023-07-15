using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp_N_tier.Business.Interfaces;
using ToDoApp_N_tier.Dtos.WorkDtos;

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
            List<WorkListDto> workListDtos = await _workService.GetAllAsync();
            return View(workListDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            if (!ModelState.IsValid) return View(workCreateDto);
            await _workService.CreateAsync(workCreateDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View(await _workService.GetByIdAsync<WorkUpdateDto>(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            if (!ModelState.IsValid) return View(workUpdateDto);
            await _workService.UpdateAsync(workUpdateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}