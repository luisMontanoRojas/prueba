using AutoMapper;
using hotelReserv.Data.Entities;
using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Data
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            this.CreateMap<HotelEntity, Hotel>()
                .ReverseMap();

            this.CreateMap<ReservEntity, Reserv>()
                .ReverseMap();
        }
    }
}
