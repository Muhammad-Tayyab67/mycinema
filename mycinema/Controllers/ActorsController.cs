using Microsoft.AspNetCore.Mvc;
using mycinema.Data;
using mycinema.Data.Services;
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
    }
}
