using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Services
{
    public interface IReservService
    {
        Task<Reserv> CreateReserv(Reserv newReserv);
        Task<IEnumerable<Reserv>> GetReservs(int id);
        Task<Reserv> GetReserv(int id);
        Task<bool> DeleteReserv(int id);
        Task<Reserv> UpdateReserv(int id, Reserv reserv);
    }
}
