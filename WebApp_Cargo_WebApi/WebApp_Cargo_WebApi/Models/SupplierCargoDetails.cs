using System;
using System.Collections.Generic;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class SupplierCargoDetails
    {
        public int SupplierId { get; set; }
        public int CargoId { get; set; }
        public DateTime? SupplyDate { get; set; }
        public string SupplyDescription { get; set; }

        public virtual Cargoes Cargo { get; set; }
        public virtual Suppliers Supplier { get; set; }
    }
}
