using System;
using System.Collections.Generic;

#nullable disable

namespace HouseStoreFront.Models
{
    public partial class House
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }

        public virtual StateEnum StateNavigation { get; set; }
    }
}
