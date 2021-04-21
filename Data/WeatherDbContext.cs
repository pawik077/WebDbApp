using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext (DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Weather> WeatherData { get; set; }
    }
}
