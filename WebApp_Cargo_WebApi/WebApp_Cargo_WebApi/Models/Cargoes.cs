using System;
using System.Collections.Generic;
using WebApp_Cargo_WebApi.Models.EFCore;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Cargoes : IEntity 
    {
        public Cargoes()
        {
            SupplierCargoDetails = new HashSet<SupplierCargoDetails>();
        }

        public int CargoId { get; set; }
        public int? CustomerId { get; set; }
        public string CargoDescription { get; set; }
        public int? CourierId { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? Freight { get; set; }
        public int? TransportId { get; set; }

        public virtual Couriers Courier { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Transports Transport { get; set; }
        public virtual ICollection<SupplierCargoDetails> SupplierCargoDetails { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
