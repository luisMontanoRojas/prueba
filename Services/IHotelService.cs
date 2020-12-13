using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Services
{
    public interface IHotelService
    {
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<IEnumerable<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<bool> DeleteHotel(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
    }
}
