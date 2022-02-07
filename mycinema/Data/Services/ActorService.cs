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
            _context.Actors.Add(actor);
            _context.SaveChanges();
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

        public async Task<Actor> getByIdasnyc(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.id == id);
             return result;
            
            
            
        }

        public async Task<Actor> update(int id, Actor newActor)
        {
            _context.Actors.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
