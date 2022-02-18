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
        public async Task<IActionResult> Filter(string searchString)
        {
            var allmovies = await _service.GetAll(n => n.Cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allmovies.Where(n => n.Name.Contains(searchString) || n.descr.Contains(searchString));
                return View("Index",filterResult);
            }

            return View("Index",allmovies);
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
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.id,
                Name = movieDetails.Name,
                descr = movieDetails.descr,
                price = movieDetails.price,
                starttime = movieDetails.starttime,
                endtime = movieDetails.endtime,
                imgurl = movieDetails.imgurl,
                MovieCategery = movieDetails.MovieCategery,
                cinemaId = movieDetails.cinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };


            var moviedropdowndata = await _service.moviedropdowns();
            ViewBag.Actors = new SelectList(moviedropdowndata.Actors, "id", "Name");
            ViewBag.Producers = new SelectList(moviedropdowndata.Producers, "id", "Name");
            ViewBag.Cinemas = new SelectList(moviedropdowndata.Cinemas, "id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {

                var moviedropdowndata = await _service.moviedropdowns();
                ViewBag.Actors = new SelectList(moviedropdowndata.Actors, "id", "Name");
                ViewBag.Producers = new SelectList(moviedropdowndata.Producers, "id", "Name");
                ViewBag.Cinemas = new SelectList(moviedropdowndata.Cinemas, "id", "Name");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
