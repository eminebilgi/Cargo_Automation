using System;
using System.Collections.Generic;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            SupplierCargoDetails = new HashSet<SupplierCargoDetails>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<SupplierCargoDetails> SupplierCargoDetails { get; set; }
    }
}
