using System;
using System.Collections.Generic;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Couriers
    {
        public Couriers()
        {
            Cargoes = new HashSet<Cargoes>();
        }

        public int CourierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public virtual ICollection<Cargoes> Cargoes { get; set; }
    }
}
