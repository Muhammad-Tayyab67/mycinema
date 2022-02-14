using mycinema.Data.Base;
using mycinema.Data.ViewModel;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public interface IMoviesServices : IEntityBaseRespository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> moviedropdowns();
        Task addnewmovieAsync(NewMovieVM data);
    }
}
