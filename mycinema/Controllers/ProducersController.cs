using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mycinema.Data;

namespace mycinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDBContext _conext;
        public ProducersController(AppDBContext context)
        {
            _conext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allproducers =await _conext.Producers.ToListAsync();
            return View();
        }
    }
}
