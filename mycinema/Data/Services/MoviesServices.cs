using Microsoft.EntityFrameworkCore;
using mycinema.Data.Base;
using mycinema.Data.ViewModel;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public class MoviesServices : EntityBaseRepository<Movie>, IMoviesServices
    {
        private readonly AppDBContext _context;
        public MoviesServices(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.id == id);
            return movieDetail;
                
        }

        public async Task<NewMovieDropdownVM> moviedropdowns()
        {
           var response=new NewMovieDropdownVM();
            response.Actors = await _context.Actors.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.Name).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            return response;
        }
    }
}
