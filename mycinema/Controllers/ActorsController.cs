using Microsoft.AspNetCore.Mvc;
using mycinema.Data;
using mycinema.Data.Services;
using mycinema.Models;
using System.Linq;
namespace mycinema.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorServies _service;
        public ActorsController(IActorServies service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("profilepicurl,Name,bio")]Actor actor)
        {
                _service.add(actor);
                return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Details(int id)
        {
            var result=await _service.getByIdasnyc(id);
            if(result==null)
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
        public async Task<IActionResult> Edit(int id,Actor actor)
        {
           await _service.update(id,actor);
            return RedirectToAction(nameof(Index));
        }

    }
}
