using AutoMapper;
using hotelReserv.Data.Entities;
using hotelReserv.Data.Repository;
using hotelReserv.Exceptions;
using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Services
{
    public class ReservService : IReservService
    {
        private IHotelRepository hotelRepository;
        private readonly IMapper mapper;

        public ReservService(IHotelRepository _hotelRepository, IMapper _mapper)
        {
            this.hotelRepository = _hotelRepository;
            this.mapper = _mapper;
        }

        private async Task validateHotelId(int hotelId)
        {
            var hotelEntity = await hotelRepository.GetHotel(hotelId);
            if (hotelEntity == null)
            {
                throw new NotFoundItemException($"cannot found pedido with id:{hotelId}");
            }
        }


        public async Task<Reserv> CreateReserv(Reserv newReserv)
        {
            var reservEntity = mapper.Map<ReservEntity>(newReserv);
            hotelRepository.CreateReserv(reservEntity);
            if (await hotelRepository.SaveChangesAsync())
            {
                return mapper.Map<Reserv>(reservEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteReserv(int id)
        {
            await hotelRepository.DeleteReserv(id);
            if (await hotelRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Reserv>> GetReservs(int id)
        {
            var reservsEntities = await hotelRepository.GetReservs(id);
            var res = mapper.Map<IEnumerable<Reserv>>(reservsEntities);
            foreach (Reserv r in res)
            {
                r.hotelId = reservsEntities.ToList().Find(reserv => reserv.id == r.id).hotelIdEntity.id;
            }
            return res;
        }

        public async Task<Reserv> GetReserv(int id)
        {
            var reservEntity = await hotelRepository.GetReserv(id);
            if (reservEntity == null)
            {
                throw new NotFoundItemException("Reserv not found");
            }
            var reserv = mapper.Map<Reserv>(reservEntity);
            reserv.hotelId = reservEntity.hotelIdEntity.id;
            return reserv;
        }

        public Task<Reserv> UpdateReserv(int id, Reserv reserv)
        {
            throw new NotImplementedException();
        }
    }
}
