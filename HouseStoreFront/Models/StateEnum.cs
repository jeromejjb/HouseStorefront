using System;
using System.Collections.Generic;

#nullable disable

namespace HouseStoreFront.Models
{
    public partial class StateEnum
    {
        public StateEnum()
        {
            Houses = new HashSet<House>();
        }

        public string State { get; set; }

        public virtual ICollection<House> Houses { get; set; }
    }
}
