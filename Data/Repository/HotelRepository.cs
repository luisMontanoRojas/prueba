using hotelReserv.Data.Entities;
using hotelReserv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelReserv.Data.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private HotelDbContext hotelDbContext;

        public HotelRepository(HotelDbContext _hotelDbContext)
        {
            this.hotelDbContext = _hotelDbContext;
        }

        //CREATE
        public void CreateHotel(HotelEntity newHotel)
        {
            hotelDbContext.Hotels.Add(newHotel);
        }

        public void  CreateReserv(ReservEntity newReserv)
        {
            //hotelDbContext.Entry(Reserv.hotelid).State = EntityState.Unchanged;
            hotelDbContext.Reservs.Add(newReserv);
        }
        //DELETE
        public async Task DeleteHotel(int id)
        {
            var hotelToDelete = await hotelDbContext.Hotels.SingleAsync(d => d.id == id);
            hotelDbContext.Hotels.Remove(hotelToDelete);
        }

        public async Task DeleteReserv(int id)
        {
            var reservToDelete = await hotelDbContext.Reservs.SingleAsync(d => d.id == id);
            hotelDbContext.Reservs.Remove(reservToDelete);
        }
        //GET ONE
        public async Task<HotelEntity> GetHotel(int id)
        {
            IQueryable<HotelEntity> query = hotelDbContext.Hotels;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(u => u.id == id);
        }

        public async Task<ReservEntity> GetReserv(int id)
        {
            IQueryable<ReservEntity> query = hotelDbContext.Reservs;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(u => u.id == id);
        }
        //GET ALL
        public async Task<IEnumerable<HotelEntity>> GetHotels()
        {
            IQueryable<HotelEntity> query = hotelDbContext.Hotels;
            var a = await query.ToArrayAsync();
            return a;
        }

        public async Task<IEnumerable<ReservEntity>> GetReservs(int id)
        {
            IQueryable<ReservEntity> query = hotelDbContext.Reservs.Where(d => d.hotelIdEntity.id == id);
            var a = await query.ToArrayAsync();
            return a;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await hotelDbContext.SaveChangesAsync()) > 0;
        }
        //UPDATE
        public void UpdateHotel(HotelEntity editHotel)
        {
            //hotelDbContext.Entry(destinatario.Usuario).State = EntityState.Unchanged;
            hotelDbContext.Hotels.Update(editHotel);
        }

        public void UpdateReserv(ReservEntity editReserv)
        {
            hotelDbContext.Reservs.Update(editReserv);
        }
    }
}
