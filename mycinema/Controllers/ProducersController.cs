using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;
using mycinema.Data.Services;
using mycinema.Models;

namespace mycinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerServices _service;
        public ProducersController(IProducerServices services)
        {
            _service=services;
        }
        public async Task<IActionResult> Index()
        {
            var allproducers =await _service.GetAll();
            return View(allproducers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("profilepicurl,Name,bio")] Producer producer)
        {
            await _service.AddAsync(producer);
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
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            await _service.update(id, producer);
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
