using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;
using mycinema.Data.Services;
using mycinema.Models;

namespace mycinema.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaServices _service;
        public CinemasController(ICinemaServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("logo,Name,desc")] Cinema cinema)
        {
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.getByIdasnyc(id);
            if (result == null)
            {
                return View("Empty");

            }
            return View(result);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.getByIdasnyc(id);
            if (result == null)
            {
                return View("Empty");

            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            await _service.update(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.getByIdasnyc(id);
            if (result == null)
            {
                return View("Empty");

            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
