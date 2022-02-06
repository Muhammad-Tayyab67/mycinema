using Microsoft.EntityFrameworkCore;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public class ActorService : IActorServies
    {
        private readonly AppDBContext _context;

        public ActorService(AppDBContext context)
        {
            _context = context;
        }
        public void add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public Actor delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var data = await _context.Actors.ToListAsync();
            return data;
        }

        public Actor getById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
