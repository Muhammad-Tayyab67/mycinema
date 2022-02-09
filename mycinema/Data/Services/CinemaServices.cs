using mycinema.Data.Base;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public class CinemaServices : EntityBaseRepository<Cinema>, ICinemaServices
    {
        public CinemaServices(AppDBContext context) : base(context) { }
    }
}
