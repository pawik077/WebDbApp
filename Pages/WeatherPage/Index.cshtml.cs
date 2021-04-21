using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.WeatherPage
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WeatherDbContext _context;

        public IndexModel(WebApplication1.Data.WeatherDbContext context)
        {
            _context = context;
        }

        public IList<Weather> Weather { get;set; }

        public async Task OnGetAsync()
        {
            Weather = await _context.WeatherData.ToListAsync();
        }
    }
}
