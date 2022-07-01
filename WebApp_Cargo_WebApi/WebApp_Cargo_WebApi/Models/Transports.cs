using System;
using System.Collections.Generic;

namespace WebApp_Cargo_WebApi.Models
{
    public partial class Transports
    {
        public Transports()
        {
            Cargoes = new HashSet<Cargoes>();
        }

        public int TransportId { get; set; }
        public string TransportType { get; set; }

        public virtual ICollection<Cargoes> Cargoes { get; set; }
    }
}
