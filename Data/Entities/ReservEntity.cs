using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelReserv.Data.Entities
{
    public class ReservEntity
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public DateTime entry { get; set; }
        [Required]
        public DateTime departure { get; set; }
        [ForeignKey("hotelId")]
        public virtual HotelEntity hotelIdEntity { get; set; }
    }
}
