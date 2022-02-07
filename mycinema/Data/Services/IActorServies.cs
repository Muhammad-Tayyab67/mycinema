using mycinema.Models;

namespace mycinema.Data.Services
{
    public interface IActorServies
    {
        Task<IEnumerable<Actor>> GetAll();
        void add(Actor actor);
        Actor delete(int id);
        
        Task <Actor> update(int id, Actor newActor);
        Task <Actor> getByIdasnyc(int id);
    }
}
