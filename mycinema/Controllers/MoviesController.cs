using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;
using mycinema.Data.Services;
using mycinema.Models;

namespace mycinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesServices _service;
        public MoviesController(IMoviesServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allmovies = await _service.GetAll(n=> n.Cinema);
            return View(allmovies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var md= await _service.GetMovieByIdAsync(id);
            return View(md);

        }
     public async Task<IActionResult> Create()
        {
            var moviedropdowndata = await _service.moviedropdowns();
            ViewBag.Actors = new SelectList(moviedropdowndata.Actors, "id", "Name");
            ViewBag.Producers = new SelectList(moviedropdowndata.Producers, "id", "Name");
            ViewBag.Cinemas = new SelectList(moviedropdowndata.Cinemas, "id", "Name");
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedropdowndata = await _service.moviedropdowns();
                ViewBag.Actors = new SelectList(moviedropdowndata.Actors, "id", "Name");
                ViewBag.Producers = new SelectList(moviedropdowndata.Producers, "id", "Name");
                ViewBag.Cinemas = new SelectList(moviedropdowndata.Cinemas, "id", "Name");
                return View(movie);
            }
            await _service.addnewmovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
