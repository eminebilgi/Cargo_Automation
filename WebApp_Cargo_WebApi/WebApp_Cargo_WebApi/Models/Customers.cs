using System;
using System.Collections.Generic;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Cargoes = new HashSet<Cargoes>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Cargoes> Cargoes { get; set; }
    }
}
