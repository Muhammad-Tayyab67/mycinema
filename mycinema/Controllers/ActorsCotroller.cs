using Microsoft.AspNetCore.Mvc;
using mycinema.Data;

namespace mycinema.Controllers
{
    public class ActorsCotroller : Controller
    {
        private readonly AppDBContext _conext;
        public ActorsCotroller(AppDBContext context)
        {
            _conext=context;
        }
        public IActionResult Index()
        {
            var data = _conext.Actors.ToList();
            return View();
        }
    }
}
