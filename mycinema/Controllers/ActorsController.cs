using Microsoft.AspNetCore.Mvc;
using mycinema.Data;
using System.Linq;
namespace mycinema.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDBContext _context;
        public ActorsController(AppDBContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View(data);
        }
    }
}
