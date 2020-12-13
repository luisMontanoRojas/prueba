﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hotelReserv.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using hotelReserv.Services;
using hotelReserv.Data.Repository;

namespace hotelReserv
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Services
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IReservService, ReservService>();
            //Repository
            services.AddTransient<IHotelRepository, HotelRepository>();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("HotelApiDatabase")
            ));

            
            
            //services.AddDbContext<HotelDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("HotelDBContext")
            //        )
            //);
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
