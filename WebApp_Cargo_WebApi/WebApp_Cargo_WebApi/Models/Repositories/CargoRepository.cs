using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cargo_WebApi.Models.EFCore;

namespace WebApp_Cargo_WebApi.Models.Repositories
{
    public class CargoRepository : GenericRepository<Cargoes>, ICargoRepository
    {
        public CargoRepository(Cargo_AutomationContext dbContext) : base(dbContext)
        {
        }

        public List<Cargoes> Search(string keyword)
        {
            return GetAll().Where(c => c.CargoDescription.Contains(keyword)).ToList();
        }

        public List<Cargoes> Search(decimal min, decimal max)
        {
            return GetAll().Where(c => c.Price >= min && c.Price <= max).ToList();
        }
    }
}
