using mycinema.Models;

namespace mycinema.Data.Services
{
    public interface IActorServies
    {
        IEnumerable<Actor> GetAll();
        void add(Actor actor);
        Actor delete(int id);
        
        void update(int id, Actor newActor);
        Actor getById(int id);
    }
}
