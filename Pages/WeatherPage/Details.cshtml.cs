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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.WeatherDbContext _context;

        public DetailsModel(WebApplication1.Data.WeatherDbContext context)
        {
            _context = context;
        }

        public Weather Weather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.WeatherData.FirstOrDefaultAsync(m => m.ID == id);

            if (Weather == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
