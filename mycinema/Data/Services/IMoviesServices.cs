using mycinema.Data.Base;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public interface IMoviesServices : IEntityBaseRespository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
