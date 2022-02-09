using mycinema.Data.Base;
using mycinema.Models;

namespace mycinema.Data.Services
{
    public class ProducerServices : EntityBaseRepository<Producer>, IProducerServices
    {
        public ProducerServices(AppDBContext context) : base(context) { }
    }
}
