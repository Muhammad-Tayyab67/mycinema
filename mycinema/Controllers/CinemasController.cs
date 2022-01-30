using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;

namespace mycinema.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDBContext _conext;
        public CinemasController(AppDBContext context)
        {
            _conext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allcinemas = await _conext.Cinemas.ToListAsync();
            return View();
        }
    }
}
