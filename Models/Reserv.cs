using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Models
{
    public class Reserv
    {
        public int? id { get; set; }
        public DateTime entry { get; set; }
        public DateTime departure { get; set; }
        public int? hotelId { get; set; }
    }
}
