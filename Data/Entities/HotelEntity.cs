using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace hotelReserv.Data.Entities
{
    public class HotelEntity
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string nationality { get; set; }
        public string url_logo_image { get; set; }
        public string facebook { get; set; }
        public string ubication { get; set; }
        public string about { get; set; }
        public string oficialPage { get; set; }
        public virtual ICollection<ReservEntity> reservs { get; set; }
    }
}
