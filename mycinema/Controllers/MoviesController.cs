using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;
using mycinema.Data.Services;

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
     
    }
}
