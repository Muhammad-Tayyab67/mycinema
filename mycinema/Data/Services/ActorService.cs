using Microsoft.EntityFrameworkCore;
using mycinema.Data.Base;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorServies
    {
      
        public ActorService(AppDBContext context) : base(context) { }
       
    }
}
