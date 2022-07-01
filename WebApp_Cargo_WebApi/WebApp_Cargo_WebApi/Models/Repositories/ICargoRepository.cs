using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cargo_WebApi.Models.EFCore;

namespace WebApp_Cargo_WebApi.Models.Repositories
{
    public interface ICargoRepository : IGenericRepository<Cargoes>
    {
        public List<Cargoes> Search(string keyword);

        public List<Cargoes> Search(decimal min, decimal max);
    }
}
