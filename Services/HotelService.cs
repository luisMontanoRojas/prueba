using AutoMapper;
using hotelReserv.Data.Entities;
using hotelReserv.Data.Repository;
using hotelReserv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Services
{
    public class HotelService : IHotelService
    {
        private IHotelRepository hotelRepository;
        private readonly IMapper mapper;
        public HotelService(IHotelRepository _hotelRepository, IMapper _mapper)
        {
            this.hotelRepository = _hotelRepository;
            this.mapper = _mapper;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            var hotelEntity = mapper.Map<HotelEntity>(hotel);
            hotelRepository.CreateHotel(hotelEntity);
            if (await hotelRepository.SaveChangesAsync())
            {
                return mapper.Map<Hotel>(hotelEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteHotel(int id)
        {
            await hotelRepository.DeleteHotel(id);
            if (await hotelRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotelEntities = await hotelRepository.GetHotel(id);
            var res = mapper.Map<Hotel>(hotelEntities);
            return res;
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotelEntities = await hotelRepository.GetHotels();
            var res = mapper.Map<IEnumerable<Hotel>>(hotelEntities);
            return res;
        }

        public Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
