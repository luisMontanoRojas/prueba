using hotelReserv.Data.Entities;
using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Data.Repository
{
    public interface IHotelRepository
    {
        Task<bool> SaveChangesAsync();
        //Hotel
        Task<IEnumerable<HotelEntity>> GetHotels();
        Task<HotelEntity> GetHotel(int id);
        void CreateHotel(HotelEntity newHotel);
        void UpdateHotel(HotelEntity editHotel);
        Task DeleteHotel(int id);


        //Reserv
        Task<IEnumerable<ReservEntity>> GetReservs(int id);
        Task<ReservEntity> GetReserv(int id);
        void CreateReserv(ReservEntity newReserv);
        void UpdateReserv(ReservEntity editReserv);
        Task DeleteReserv(int id);
    }
}
