using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;

namespace mycinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDBContext _conext;
        public MoviesController(AppDBContext context)
        {
            _conext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allmovies = await _conext.Movies.ToListAsync();
            return View(allmovies);
        }
    }
}
