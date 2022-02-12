using Microsoft.EntityFrameworkCore;
using mycinema.Data.Base;
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
    }
}
