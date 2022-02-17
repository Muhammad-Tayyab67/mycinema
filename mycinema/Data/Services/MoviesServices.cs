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

        public async Task addnewmovieAsync(NewMovieVM data)
        {
            var newmovie = new Movie();
           newmovie.Name = data.Name;
            newmovie.starttime = data.starttime;
            newmovie.endtime = data.endtime;
            newmovie.imgurl = data.imgurl;  
            newmovie.MovieCategery=data.MovieCategery;
            newmovie.price= data.price;
            newmovie.ProducerId = data.ProducerId;
            newmovie.cinemaId = data.cinemaId;
            newmovie.descr= data.descr; 
            await _context.AddAsync(newmovie);
            await _context.SaveChangesAsync();

            foreach(var actorid in data.ActorIds)
            {
                var newactorid = new Actor_Movie();
                    newactorid.MovieId = newmovie.id;
                newactorid.ActorId = actorid;
                await _context.Actors_Movies.AddAsync(newactorid); 
            }
            await _context.SaveChangesAsync();
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

      
        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.descr = data.descr;
                dbMovie.price = data.price;
                dbMovie.imgurl = data.imgurl;
                dbMovie.cinemaId = data.cinemaId;
                dbMovie.starttime = data.starttime;
                dbMovie.endtime = data.endtime;
                dbMovie.MovieCategery = data.MovieCategery;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync(); 
        }
    }
}
