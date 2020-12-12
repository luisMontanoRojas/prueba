using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Models
{
    public class Hotel
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string url_logo_image { get; set; }
        public string facebook { get; set; }
        public string ubication { get; set; }
        public string about { get; set; }
        public string oficialPage { get; set; }
        public IEnumerable<Reserv> reservs { get; set; }
    }
}
